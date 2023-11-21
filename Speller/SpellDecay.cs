using Godot;
using System;

public partial class SpellDecay : Timer
{
	public override void _PhysicsProcess(double delta)
	{
		GD.Print(TimeLeft);
	}
	
	
}
