using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator2D {
	public class Vector2D {

		public int x;
		public int y;

		public static readonly Vector2D UP = new Vector2D (0, -1);
		public static readonly Vector2D DOWN = new Vector2D (0, 1);
		public static readonly Vector2D LEFT = new Vector2D (-1, 0);
		public static readonly Vector2D RIGHT = new Vector2D (1, 0);
		public static readonly Vector2D ZERO = new Vector2D ();

		public static readonly Vector2D[] directions = new Vector2D[] {
			UP,
			DOWN,
			LEFT,
			RIGHT
		};

		public Vector2D () {
			this.x = 0;
			this.y = 0;
		}

		public Vector2D (int x, int y) {
			this.x = x;
			this.y = y;
		}

		public static Vector2D sum (Vector2D first, Vector2D second) {
			return new Vector2D (first.x + second.x, first.y + second.y); 
		}
		public static Vector2D sum (params Vector2D[] arguments) {
			Vector2D sum = new Vector2D ();
			foreach (Vector2D arg in arguments) {
				sum.x += arg.x;
				sum.y += arg.y;
			}
			return sum;
		}
		public static Vector2D dif (Vector2D first, Vector2D second) {
			return new Vector2D (first.x - second.x, first.y - second.y); 
		}

		public override string ToString () {
			return "x = " + x + " y = " + y;
		}

		public static Vector2D operator + (Vector2D first, Vector2D last) {
			return sum (first, last);
		}

		public static Vector2D operator - (Vector2D first, Vector2D last) {
			return dif (first, last);
		}
	}
}