using Godot;
using System;

public static class GenerallyUsefulMethods : Object
{
	//Want to convert from a direction vector to a rotation (Godot just uses radians)
	public static float Angle(Vector2 Direction)
	{
		Direction = Direction.Normalized();
		if (Direction.Y >= 0)
			return (float)Math.Acos(Direction.X);
		else 
			return (float)-Math.Acos(Direction.X);
	}
}
