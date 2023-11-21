using Godot;
using System;
using Element;

public partial class Player : CharacterBody2D, ITakesDamage, ICaster
{
	public AnimatedSprite2D Animations;
	public StatesManager States;
	
	private IElement element;
	public IElement Element{get;}
	
	private int health = 100;
	public int Health{get{return health;} private set{health = value;}}
	
	public void Damage(int damage, IElement element)
	{
		Health -= damage;
	}
	
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
		if (@event.IsActionPressed("Cast"))
		{
			Cast();
		}
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
	
	private void Cast()
	{
		SpellBase fireBolt = (SpellBase)ResourceLoader.Load<PackedScene>("res://fire_bolt.tscn").Instantiate();
		fireBolt.SetUp(this);
		AddChild(fireBolt);
	}
}
