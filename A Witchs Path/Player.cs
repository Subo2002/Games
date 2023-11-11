using Godot;
using System;
using Physics;

public partial class Player : Area2D
{
	private float StartingZ = 0;
	
	private Sphere BoundingSphere;
	private Vector3 Position3D;
	[Export]
	private float Speed;
	[Export]
	private NodePath tileMap;
	private Godot.Collections.Array<Node> CollidingObjects;
	
	private void ZUpdate() {ZIndex = (int)Math.Floor(Position3D.Z); }
	
	public override void _Ready() {
		Position3D = Isometric.Lift(Position, StartingZ) + new Vector3(0, 0, 0.4f);
		BoundingSphere = new Sphere(Position3D, 0.4f);
		
	}
	
	public override void _PhysicsProcess(double delta) {
		//Set Up
		//RayCast downwards to find floor, then alter the direction vector accordingly
		//Also need to see if above floor, then apply gravity
		Vector3 Direction = input(); 
		Vector3 Velocity = Direction * Speed;
		CollidingObjects = GetNode(tileMap).GetChildren();
		
		
		//Attempt Movement
		Vector3 Delta = Velocity * (float) delta;
		Position3D += Delta;
		BoundingSphere = new Sphere(Position3D, 0.4f);
		//Collision
		foreach(Node n in CollidingObjects) 
		{
			Tile tile = (Tile) n ;
			Intersection intersection = Collision.Collide(BoundingSphere, tile.Shape);
			if (intersection.Intersect)
			{
				Position3D += tile.CollisionResponse(intersection, Delta);
			}
		}
		Position = Isometric.Project(Position3D);
		BoundingSphere = new Sphere(Position3D, 0.4f);
		ZUpdate();
	}
	
	private Vector3 input() {
		Vector2 vector =  new Vector2(Input.GetActionStrength("Right") - Input.GetActionStrength("Left"),
						   			  (Input.GetActionStrength("Down") - Input.GetActionStrength("Up"))/2);
		return Isometric.Lift(vector * 16, 0).Normalized();
	}
}






