using Godot;
using System;
using System.Collections.Generic;

public partial class SpellBase : Area2D
{
	public Boolean Setup = false; //Not so nice
	
	public ICaster Caster;
	
	[Export]
	Form Form;
	
	private float spellLength;
	public float SpellLength{get{return spellLength;} set{spellLength = value;}}
	
	[Export]
	private NodePath PathAnimations;
	
	[Export]
	private String AnimationName;
	
	private AnimatedSprite2D Animations;
	
	private List<SpellComponent> spellComponents = new List<SpellComponent>();
	
	public override void _Ready()
	{
		Animations = (AnimatedSprite2D) GetNode(PathAnimations);
		Animations.Play(AnimationName);
		foreach (Node Child in GetChildren())
		{
			if (typeof(SpellComponent).IsInstanceOfType(Child))
			{
				((SpellComponent)Child).SetUp(this);
				spellComponents.Add((SpellComponent)Child);
			}
		}
	}
	
	public override void _PhysicsProcess(double delta)
	{
		if (Setup)
		{
			Form.PhysicsProcess(delta);
		}
	}
	
	private void _on_body_entered(Node2D body)
	{
		foreach (SpellComponent component in spellComponents)
		{
			component.Hit(body); //No death as some spell do not die on a hit
		}
	}
	
	public void Death()
	{
		GD.Print("I Die");
		QueueFree();
	}
	
	public void SetUp(ICaster caster)
	{
		GD.Print("SpellBase set up");
		Caster = caster;
		//Timer spellDecay = (Timer)GetNode("SpellDecay");
		//GD.Print("Spell Length:" + SpellLength);
		//spellDecay.WaitTime = SpellLength;
		Setup = true; //Not so nice
	}
	
}


