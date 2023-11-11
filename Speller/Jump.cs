using Godot;
using System;

public partial class Jump : StateBase
{
	[Export]
	private NodePath PathIdle;
	private StateBase Idle;
	[Export]
	private float SpeedJump = -300;
	[Export]
	private float SpeedSideJump = 400;
	[Export]
	private float GravityJumpFalling = 980;
	
	private bool NotInAir = true;
	private Vector2 velocity = Vector2.Zero;
	private float Direction = 0;
	
	public override void _Ready()
	{
		Idle = (StateBase)GetNode(PathIdle);
	}
	
	public override void Enter()
	{
		player.Animations.Play(animationName);
		
	}
	
	public override StateBase PhysicsProcess(double delta)
	{
		velocity = player.Velocity;
		if (NotInAir)
		{
			if (Input.IsActionPressed("left"))
			{
				Direction = -1;
				player.Animations.FlipH = true;
			}
			else if (Input.IsActionPressed("right"))
			{
				Direction = 1;
				player.Animations.FlipH = false;
			}
			velocity = new Vector2(Direction*SpeedSideJump, SpeedJump);
			NotInAir = false;
		}
		else
			velocity.Y += GravityJumpFalling*(float)delta;
		
		player.Velocity = velocity;
		player.MoveAndSlide();
		if (player.IsOnFloor())
		{
			Direction = 0;
			NotInAir = true;
			velocity = Vector2.Zero;
			return Idle;
		}
		return this;
	}

}
