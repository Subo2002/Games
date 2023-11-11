using Godot;
using System;

public partial class Layer : TileMap
{
	private int layerIndex;
	
	public override void _Ready()
	{
		layerIndex = ZIndex;
	}
	
	/*
	public Node[] Search(Vector3 thing)
	{
		int l = (int)(thing.z);
		if (layerIndex == l)
		{
			
		}
		else if (layerIndex == l + 1)
		{
			
		}
	}
	*/
}
