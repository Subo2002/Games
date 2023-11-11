using Godot;
using System;
using Element;

public partial class Bolt : Area2D
{
	Vector2 Velocity = Vector2.Zero;
	
	[Export]
	float InitialSpeed;
	
	IElement Element;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	
	public void Cast(IElement element)
	{
		Element = element;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		//Velocity = InitialSpeed*Direction;
		//Position += Velocity*(float)delta;
	}
}
