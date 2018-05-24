using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator2D {
	public class Bridge : Node {

		private bool doubleBridge;
		private Vector2D direction;

		public Bridge(int x, int y, bool isDouble, Vector2D direction) : base (x, y) {
			doubleBridge = isDouble;
			this.direction = direction;
		}

		public Bridge (Vector2D position, bool isDouble, Vector2D direction) : base (position) {
			doubleBridge = isDouble;
			this.direction = direction;
		}

		public Vector2D getDirection () {
			return direction;
		}

		public bool isDoubleBridge() {
			return doubleBridge;
		}

		public void setDoubleBridge(bool doubleBridge) {
			this.doubleBridge = doubleBridge;
		}

	}
}