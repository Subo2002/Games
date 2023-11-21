using Godot;
using System;
using System.Collections.Generic;

namespace Element
{
	public enum ElementType
	{
		Fire,
		Water,
		Poison
	}

	public interface IElement
	{
		public ElementType Element {get;}
		
		//The Element types this element is weak to
		public List<IElement> Weaknesses {get;}
		
		//The Element types this element is strong against
		public List<IElement> Strengths {get;}
		
	}
	
	public abstract class ElementBase : IElement
	{
		//Properties
		public virtual ElementType Element {get;}
		
		public abstract List<IElement> Weaknesses {get;}
		public abstract List<IElement> Strengths {get;} 
	}


	
	public partial class Fire : ElementBase
	{
		//Fields
		private ElementType element = ElementType.Fire;
		
		private List<IElement> weaknesses = new List<IElement> {new Water()};
		private List<IElement> strengths = new List<IElement>();
		
		//Properties
		public override ElementType Element => element;
		
		public override List<IElement> Weaknesses => weaknesses;
		public override List<IElement> Strengths => strengths;
		
		
		public float PropulsionSpeed(float M, float T) //M is the mass of the fireball at the current time (T)
		{
			//Given a unit of mass how much velocity does it produce
			float C = 100;
			
			//How much mass does it burn per second
			float R = 1;
			
			//if too slow to compute might look in to chebyshev poly approximation for log
			return C * (float)Math.Log(M/(M-R*T));
		}
	}

	public partial class Water : ElementBase
	{
		//Fields
		private ElementType element = ElementType.Water;
		
		private List<IElement> weaknesses = new List<IElement>();
		private List<IElement> strengths = new List<IElement>();
		
		//Properties
		public override ElementType Element => element;
		
		public override List<IElement> Weaknesses => weaknesses;
		public override List<IElement> Strengths => strengths;
	}
	
	public partial class Poison : ElementBase
	{
		private ElementType element = ElementType.Poison;
		
		private List<IElement> weaknesses = new List<IElement>();
		private List<IElement> strengths = new List<IElement>();
		
		//Properties
		public override ElementType Element => element;
		
		public override List<IElement> Weaknesses => weaknesses;
		public override List<IElement> Strengths => strengths;
		
		
	}
}
