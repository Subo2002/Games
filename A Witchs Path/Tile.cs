using Godot;
using System;
using Physics;
using System.Collections.Generic;
using static Isometric.Directions;

public partial class Tile : Area2D
{
	//Fields
	[Export]
	private String identity;
	protected IPhysicsObject shape;
	private float z;
	private Vector3 position3D;
	private static Vector3 floorNormal;
	private static Dictionary<Vector2, Vector3> floorDictionary = DirectionTranslate(floorNormal);
	
	//Properties
	public String Identity {get{return identity;}}
	public IPhysicsObject Shape {get{return shape;}}
	public Vector3 Position3D {get{return position3D;}}
	public Dictionary<Vector2, Vector3> FloorDictionary {get{return floorDictionary;}}
	
	public override void _Ready()
	{
		position3D = Isometric.Lift(Position, z);
	}
	
	public virtual Vector3 CollisionResponse(Intersection intersection, Vector3 Delta) {
		return -Delta;
	}
	
	public override String ToString() {
		return $"is a {identity} at position {Position3D}";
		
	}
}
