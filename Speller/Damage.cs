using Godot;
using System;
using Element;

public interface ITakesDamage
{
	int Health{get;}
	
	IElement Element{get;}
	
	void Damage(int damage, IElement element);
}
