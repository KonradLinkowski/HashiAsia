using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator3D {
	public class Vector3D {

		public int x;
		public int y;
		public int z;

		public static readonly Vector3D UP = new Vector3D (0, -1, 0);
		public static readonly Vector3D DOWN = new Vector3D (0, 1, 0);
		public static readonly Vector3D LEFT = new Vector3D (-1, 0, 0);
		public static readonly Vector3D RIGHT = new Vector3D (1, 0, 0);
		public static readonly Vector3D FORWARD = new Vector3D (0, 0, -1);
		public static readonly Vector3D BACK = new Vector3D (0, 0, 1);
		public static readonly Vector3D ZERO = new Vector3D ();

		public static readonly Vector3D[] directions = new Vector3D[] {
			UP,
			DOWN,
			LEFT,
			RIGHT,
			FORWARD,
			BACK
		};

		public Vector3D () {
			this.x = 0;
			this.y = 0;
			this.z = 0;
		}

		public Vector3D (int x, int y, int z) {
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static Vector3D sum (Vector3D first, Vector3D second) {
			return new Vector3D (first.x + second.x, first.y + second.y, first.z + second.z); 
		}
		public static Vector3D sum (params Vector3D[] arguments) {
			Vector3D sum = new Vector3D ();
			foreach (Vector3D arg in arguments) {
				sum.x += arg.x;
				sum.y += arg.y;
				sum.z += arg.z;
			}
			return sum;
		}
		public static Vector3D dif (Vector3D first, Vector3D second) {
			return new Vector3D (first.x - second.x, first.y - second.y, first.z - second.z); 
		}

		public override string ToString () {
			return "x = " + x + " y = " + y + " z = " + z;
		}

		public static Vector3D operator + (Vector3D first, Vector3D last) {
			return sum (first, last);
		}

		public static Vector3D operator - (Vector3D first, Vector3D last) {
			return dif (first, last);
		}
	}
}