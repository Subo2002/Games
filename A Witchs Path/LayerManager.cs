using Godot;
using System;
using System.Collections.Generic;

public partial class LayerManager : Node
{
	private Godot.Collections.Array<Node> children;
	private Dictionary<int, Node> layerDict = new Dictionary<int,Node>(0);
	
	public override void _Ready() 
	{
		children = GetChildren();
		foreach (Node child in children)
		{
			layerDict.Add(( (TileMap)child).ZIndex, child);
		}
	}
	
	/*
	public Node[][] Search(Vector3 thing)
	{
		int l = (int)thing.Z;
		Node[][] A = new Node[][2];
		A[0] = (Layer)(layerDict[l]).Search(thing);
		A[1] = (Layer)(layerDict[l+1]).Search(thing);
		return A;
	}
	*/
}
