using Godot;
using System;
using Element;
using static GenerallyUsefulMethods;

public partial class Bolt : Form
{
	
	Vector2 velocity;
	
	//private const float spellLength = 10;
	//public float SpellLength{get;}
	
	
	Vector2 direction = new Vector2(1, 0);
	public Vector2 Direction
	{
		set
		{
			value = value.Normalized();
			direction = value;
			Spell.Rotation = Angle(value);
		}
		
		get{return direction;}
	}
	
	[Export]
	float speed;
	
	public override void SetUp(SpellBase spell)
	{
		//GD.Print("Bolt SetUp");
		this.Spell = spell;
		//spell.SpellLength = spellLength;
		Direction = ((Node2D)spell.Caster).GetGlobalMousePosition() - ((Node2D)spell.Caster).Position; //
		Spell.Position += Direction*20; //Cast the spell infront of player by a bit
		
	}
	
	public override void PhysicsProcess(double delta)
	{
		velocity = speed*Direction;   //Using a mixture of properties and fields, maybe not nice
		Spell.Position += velocity*(float)delta;
	}
	
	public override void Hit(Node2D thing)
	{
		Spell.Death();
		if(thing is ITakesDamage damaged)
			damaged.Damage(10, new Fire());
	}
	
}
