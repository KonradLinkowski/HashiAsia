using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator3D {
	public class Bridge3D : Node3D {

		private bool doubleBridge;
		private Vector3D direction;

		public Bridge3D(int x, int y, int z, bool isDouble, Vector3D direction) : base (x, y, z) {
			doubleBridge = isDouble;
			this.direction = direction;
		}

		public Bridge3D (Vector3D position, bool isDouble, Vector3D direction) : base (position) {
			doubleBridge = isDouble;
			this.direction = direction;
		}

		public Vector3D getDirection () {
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