using Godot;
using System;

public partial class Idle : StateBase
{
	[Export] 
	private NodePath PathWalking;
	private StateBase Walking;
	
	[Export] 
	private NodePath PathFalling;
	private StateBase Falling;
	
	[Export] 
	private NodePath PathJump;
	private StateBase Jump;
	
	public override void _Ready()
	{
		Walking = (StateBase)GetNode(PathWalking);
		Falling = (StateBase)GetNode(PathFalling);
		Jump = (StateBase)GetNode(PathJump);
	}
	
	public override void Enter()
	{
		player.Animations.Play(animationName);
		if (!player.IsOnFloor())
			states.ChangeState(Falling);
	}
	
	public override StateBase InputHandler(InputEvent inputEvent)
	{
		if (inputEvent.IsAction("jump"))
			return Jump;
		else if (inputEvent.IsAction("left") || inputEvent.IsAction("right"))
			return Walking;
		else
			return this;
	}
	
	public override StateBase PhysicsProcess(double delta)
	{
		if (!player.IsOnFloor())
			return Falling;
		else
			return this;
	}
}
