using Godot;
using System;
using Physics;

public partial class Slope : Tile
{
	private Vector3 normal;
	private Physics.Slope slope;
	private static Vector3 floorNormal = new Vector3(0, 1, 1).Normalized();
	
	public Vector3 Normal{get{return normal;}}
	
	
	public override void _Ready() {
		base._Ready();
		slope = new Physics.Slope((new Vector3(0, 1, 1)).Normalized(), Position3D);
		shape = slope;
		normal = slope.Normal;
	}
	
	
	public override Vector3 CollisionResponse(Intersection intersection, Vector3 Delta) {
		Vector3 response = new Vector3(0, 0, 0);
		//float s = (intersection.Distance)/(Delta.Dot(slope.Normal));
		//Vector3 RDelta = s * Delta;
		//response -= RDelta;
		response -= Delta;
		response += (Delta -(Delta.Dot(slope.Normal)) * slope.Normal).Normalized()*Delta.Length();
		return response;
	}
	
	
}
