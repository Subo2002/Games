using Godot;
using System;
using System.Collections.Generic;

public static class Isometric {
	public static Transform2D IsoToScreen = new Transform2D(16, 8, -16, 8, 0, 0);
	public static Transform2D ScreenToIso = new Transform2D(1/32.0f, -1/32.0f, 1/16.0f, 1/16.0f, 0, 0);
	
	public static class Directions
	{
		public static Vector2 N = new Vector2(0, -1);
		public static Vector2 NW = new Vector2(-1, -1).Normalized();
		public static Vector2 W = new Vector2(-1, 0);
		public static Vector2 SW = new Vector2(-1, 1).Normalized();
		public static Vector2 S = new Vector2(0, 1);
		public static Vector2 SE = new Vector2(1, 1).Normalized();
		public static Vector2 E = new Vector2(1, 0);
		public static Vector2 NE = new Vector2(1, -1).Normalized();
		
		public static Dictionary<Vector2, Vector3> DirectionTranslate(Vector3 Normal)
		{
			return new Dictionary<Vector2, Vector3>{
				{N, Isometric.Along(N, Normal)}, 
				{NW, Isometric.Along(NW, Normal)}, 
				{W, Isometric.Along(NW, Normal)}, 
				{SW, Isometric.Along(NW, Normal)}, 
				{S, Isometric.Along(NW, Normal)}, 
				{SE, Isometric.Along(NW, Normal)}, 
				{E, Isometric.Along(NW, Normal)}, 
				{NE, Isometric.Along(NW, Normal)}
			};
		}
	}
	
	//Does isometric projection
	public static Vector2 Project(Vector3 vector) 
	{
		Vector2 XY = new Vector2(vector.X, vector.Y);
		float Z = vector.Z;
		XY = IsoToScreen*XY;
		XY.Y -= 16 * Z;
		return XY;
	}
	
	//Given 2D vector gives the corrosponding vector in 3D space, needs a Z value of course
	public static Vector3 Lift(Vector2 vector, float StartingZ) 
	{
		Vector2 PositionIso = ScreenToIso * vector;
		return new Vector3(PositionIso.X, PositionIso.Y, StartingZ);
	}
	
	//Projects 2D vectors on to a given plane (takes the normal to the plane), returns normalized vector.
	public static Vector3 Along(Vector2 input, Vector3 normal)
	{
		input = ScreenToIso*input;
		Vector3 flat = new Vector3(input.X, input.Y, 0);
		return (flat - (flat.Dot(normal))*normal).Normalized();
	}
	
	
}
