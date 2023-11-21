using Godot;
using System;

public partial class SpellComponent : Node
{
	SpellBase spell;
	public SpellBase Spell
	{
		set{spell = value;}
		get{return spell;}
	}
	
	public virtual void SetUp(SpellBase spell)
	{
		this.spell = spell;
	}
	
	public virtual void PhysicsProcess(double delta)
	{
		
	}
	
	public virtual void InputHandler(InputEvent input)
	{
		
	}
	
	public virtual void Hit(Node2D thing)
	{
		
	}
	
	
}
