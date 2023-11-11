using Godot;
using System;

public partial class Falling : StateBase
{
	[Export]
	private NodePath PathIdle;
	private StateBase Idle;
	
	[Export]
	private float GravityFalling = 980;
	
	public override void _Ready()
	{
		Idle = (StateBase) GetNode(PathIdle);
	}
	
	public override StateBase PhysicsProcess(double delta)
	{
		Vector2 velocity = player.Velocity;
		velocity.Y += GravityFalling*(float)delta;
		player.Velocity = velocity;
		player.MoveAndSlide();
		if (player.IsOnFloor())
			return Idle;
		else
			return this;
		
	}

	
}
