using Godot;
using System;

public partial class StatesManager : Node
{
	[Export]
	public NodePath StartState;
	
	public StateBase CurrentState;
	
	public void ChangeState(StateBase NextState)
	{
		if (CurrentState != null)
			CurrentState.Exit();
		CurrentState = NextState;
		CurrentState.Enter();
	}
	
	public void Initialize(Player player)
	{
		foreach (StateBase child in GetChildren())
		{
			child.player = player;
			child.states = this;
		}
		ChangeState((StateBase)GetNode(StartState));
	}
	
	public void PhysicsProcess(double delta)
	{
		CurrentState = CurrentState.PhysicsProcess(delta);
	}
	
	public void InputHandler(InputEvent inputEvent)
	{
		CurrentState = CurrentState.InputHandler(inputEvent);
	}
	
	public void Process(double delta)
	{
		CurrentState = CurrentState.Process(delta);
	}
	
	
}
