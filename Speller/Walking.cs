using Godot;
using System;

public partial class Walking : StateBase
{
	[Export]
	private NodePath PathIdle;
	private StateBase Idle;
	
	[Export]
	private NodePath PathJump;
	private StateBase Jump;
	
	public override void _Ready()
	{
		Idle = (StateBase)GetNode(PathIdle);
		Jump = (StateBase)GetNode(PathJump);
	}
	
	
	[Export]
	public float Speed = 400.0f;
	
	public override StateBase PhysicsProcess(double delta)
	{
		Vector2 velocity = Vector2.Zero;
		float Direction = 0;
		
		if (Input.IsActionPressed("jump"))
			return Jump;
		else if (Input.IsActionPressed("left"))
		{	
			Direction = -1;
			player.Animations.FlipH = true;
		}
		else if (Input.IsActionPressed("right"))
		{
			Direction  = 1;
			player.Animations.FlipH = false;
		}
		
		
		if (Direction != 0)
		{
			velocity.X = Direction * Speed;
			player.Velocity = velocity;
			player.MoveAndSlide();
			return this;
		}
		else if (player.IsOnFloor())
		{
			//velocity.X = Mathf.MoveToward(player.Velocity.X, 0, player.Speed);
			return Idle;
		}
		//Should put fallin here!!!!!!!!!!!!
		else
		{
			return Idle;
		}
	}
}
