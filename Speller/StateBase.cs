using Godot;
using System;

interface IState
{
	String AnimationName {get;}
	StatesManager States {get;}
	Player Player {get; set;}
	void Enter();
	void Exit();
	StateBase InputHandler(InputEvent inputEvent);
	StateBase Process(double delta);
	StateBase PhysicsProcess(double delta);
}

public partial class StateBase : Node, IState
{
	//Fields
	public String animationName;
	
	public StatesManager states;
	
	public Player player{get; set;}
	
	//Properties
	[Export]
	public String AnimationName {get; set;}
	
	public StatesManager States {get; set;}
	
	public Player Player {get; set;}
	
	public virtual void Enter()
	{
		player.Animations.Play(animationName);
	}
	
	public virtual void Exit()
	{
		
	}
	
	public virtual StateBase InputHandler(InputEvent inputEvent)
	{
		return this;
	}
	
	public virtual StateBase Process(double delta)
	{
		return this;
	}
	
	public virtual StateBase PhysicsProcess(double delta)
	{
		return this;
	}
}
