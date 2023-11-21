using Godot;
using System;
using Element;

public partial class Mob : RigidBody2D, ITakesDamage, ICaster
{
	private IElement element;
	public IElement Element{get{return element;}}
	
	private int health = 100;
	public int Health{get{return health;} private set{health = value;}}
	
	public override void _Ready()
	{
		Health = health;
	}
	
	public void Damage(int damage, IElement element)
	{
		Health -= damage;
		GD.Print(Health);
		if (Health <= 0)
			Death();
	}
	
	private void Death()
	{
		GD.Print("I die");
	}

}
