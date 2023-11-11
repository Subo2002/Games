using Godot;
using System;
namespace Physics {
	public static class Collision {
	
		public static Intersection Collide(IPhysicsObject Object1, IPhysicsObject Object2) {
			if (Object1.GetType() == typeof(Sphere) && Object2.GetType() == typeof(Slope))
				return SphereSlope((Sphere)Object1, (Slope)Object2);
			else if (Object1.GetType() == typeof(Slope) && Object2.GetType() == typeof(Sphere))
				return SphereSlope((Sphere)Object2, (Slope)Object1);
			else if (Object1.GetType() == typeof(Sphere) && Object2.GetType() == typeof(Cuboid))
					return SphereCuboid((Sphere)Object1, (Cuboid)Object2);
			else if (Object1.GetType() == typeof(Cuboid) && Object2.GetType() == typeof(Sphere))
				return SphereCuboid((Sphere)Object2, (Cuboid)Object1);
			else
				return null;
			}
		
		/*
		public static Tile SphereCast(Sphere sphere, Vector3 direction)
		{
			
		}
		*/
		
		
		
		public static Intersection SpherePlane(Sphere sphere, Plane plane) {
			float Distance = (sphere.Center).Dot(plane.Normal) - plane.D - sphere.Radius;
			return new Intersection(Distance < 0, Distance, sphere, plane);
		}
		
		public static Intersection SphereCuboid(Sphere sphere, Cuboid cuboid) {
			float Distance = cuboid.SquaredDistanceToPoint(sphere.Center) - sphere.Radius*sphere.Radius;
			return new Intersection(Distance < 0, Distance, sphere, cuboid);
		}
		
		public static Intersection SphereSlope(Sphere sphere, Slope slope)  {
			Intersection plane = SpherePlane(sphere, slope.Plane);
			Intersection cube = SphereCuboid(sphere, slope.Cube);
			return new Intersection(plane.Intersect && cube.Intersect, plane.Distance, sphere, slope);
		}
	}

	public partial class Intersection{
		private bool intersect;
		private float distance;
		private IPhysicsObject object1;
		private IPhysicsObject object2;
		
		public bool Intersect {get{return intersect;}}
		public float Distance {get{return distance;}}
		public IPhysicsObject Object1 {get{return object1;}}
		public IPhysicsObject Object2 {get{return object2;}}
		
		public Intersection(bool intersect, float distance, IPhysicsObject Object1, IPhysicsObject Object2) {
			this.intersect = intersect;
			this.distance = distance;
			this.object1 = Object1;
			this.object2 = Object2;
		}
	}
	

	public interface IPhysicsObject {}
	
/*
	public class UnorderedPair<T1, T2>{
		private T1 object1;
		private T2 object2;
		
		public UnorderedPair(T1 object1, T2 object2) {
			this.object1 = object1;
			this.object2 = object2;
		}
		
		public override bool Equals(Object thing) {
			if (thing.GetType() == this.GetType())
			{
				if (object1 == thing.object1 && object2 == thing.object2) {return true;}
				else if (object1 == thing.object2 && object2 == thing.object1) {return true;} //Possibility that T1 == T2
				else {return false;}
			}
			else if (thing.GetType() == UnorderedPair<T2, T1>)
			{
				if (object1 == thing.object2 && object2 == thing.object1) {return true;}
				else {return false;}
			}
			else
				return false;
		}
		
		public int Search(Object thing) {
			if (object1 == thing) {return 0;}
			else if (object2 == thing) {return 1;}
			else {return -1;}
		}
	}
*/
	
	
	public partial class Sphere : IPhysicsObject {
		private Vector3 center;
		private float radius;
		
		public Vector3 Center { get{return center;} } 
		public float Radius {get{return radius;}}
		
		public Sphere(Vector3 center, float radius) {
			this.center = center;
			this.radius = radius;
		}
		
		public override String ToString() {
			return $"Sphere of radius {radius} centered at {center}";
		}
	}
	
	public partial class Plane : IPhysicsObject {
		private Vector3 normal;
		private Vector3 point; 
		private float d;
		
		public Vector3 Normal {get{return normal;}}
		public Vector3 Point {get{return point;}}
		public float D {get{return d;}}
		
		public Plane(Vector3 normal, Vector3 point) {
			this.normal = normal.Normalized();
			this.point = point;
			d = point.Dot(normal);
		}
		
		public override String ToString() {
			return $"Plane with normal {normal}, containing point {point}";
		}
	}
	
	public partial class Cuboid : IPhysicsObject {
		private Vector3 frontVertex;
		private Vector3 volume;
		
		public Vector3 FrontVertex {get;}
		public Vector3 Volume {get;}
		
		public Cuboid(Vector3 frontVertex, Vector3 volume) {
			this.frontVertex = frontVertex;
			this.volume = volume;
		}
		
		private float SquaredIntervalDistance(float min, float max, float val) {
			if (val < min) {return (min - val) * (min - val);}
			else if (val > max) {return (val - max) * (val - max);}
			else {return 0;}
		}
		
		public float SquaredDistanceToPoint(Vector3 point) {
			float X = SquaredIntervalDistance(frontVertex.X - volume.X, frontVertex.X, point.X);
			float Y = SquaredIntervalDistance(frontVertex.Y - volume.Y, frontVertex.Y, point.Y);
			float Z = SquaredIntervalDistance(frontVertex.Z, frontVertex.Z + volume.Z, point.Z);
			return X + Y + Z;
		}
		
	}

	public partial class Slope : IPhysicsObject {
		private Plane plane;
		private Cuboid cube;
		private Vector3 normal;
		private Vector3 point;
		private float d;
		
		public Plane Plane {get{return plane;}}
		public Cuboid Cube {get{return cube;}}
		public Vector3 Normal {get{return plane.Normal;}}
		public Vector3 Point {get{return plane.Point;}}
		public float D {get{return plane.D;}}
		
		public Slope(Vector3 normal, Vector3 point) {
			this.normal = normal;
			this.point = point;
			plane = new Plane(normal, point);
			this.d = plane.D;
			cube = new Cuboid(point, new Vector3(1, 1, 1));
		}
		
		public override String ToString() {
			return $"Plane with normal {normal}, containing point {point}";
		}
	}
	
	
}

