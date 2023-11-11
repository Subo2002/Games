using Godot;
using System;
using Physics;

public partial class Cube : Tile
{
	private Physics.Cuboid cuboid;
	private static Vector3 floorNormal = new Vector3(0, 0, 1);
	
	public override void _Ready() {
		base._Ready();
		cuboid = new Physics.Cuboid(Position3D, new Vector3(1, 1, 1));
		shape = cuboid;
	}
}
