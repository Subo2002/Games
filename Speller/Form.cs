using Godot;
using System;

public partial class Form : SpellComponent
{
	public override void Hit(Node2D thing)
	{
		Spell.Death();
	}
}
