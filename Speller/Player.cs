using Godot;
using System;

public partial class Player : Godot.CharacterBody2D
{
	public AnimatedSprite2D Animations;
	public StatesManager States;
	
	public override void _Ready()
	{
		Animations = (AnimatedSprite2D) GetNode("Animations");
		States = (StatesManager)GetNode("StatesManager");
		States.Initialize((Player)this);
	}
	
	//Should use for things that don't rely on framerate, e.g. button presses
	public override void _Input(InputEvent @event)
	{
		States.InputHandler(@event);
	}
	
	//Should use for physicsal things that rely on framerate, as PhysicsProcess uses a fixed 
	public override void _PhysicsProcess(double delta)
	{
		States.PhysicsProcess(delta);
	}
	
	public override void _Process(double delta)
	{
		States.Process(delta);
	}
	
	//SCARY:
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
}
