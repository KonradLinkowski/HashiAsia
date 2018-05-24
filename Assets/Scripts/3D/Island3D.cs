using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator3D {
	public class Island3D : Node3D {

		private int value;

		public Island3D(int x, int y, int z) : base (x, y, z) {
		}

		public Island3D (Vector3D position) : base (position) {
		}

		public void setValue (int value) {
			this.value = value;
		}
		public int getValue () {
			return value;
		}

		public void reValue (Board3D board) {
			int sum = 0;
			Node3D tempNode;
			foreach (Vector3D direction in Vector3D.directions) {
				if (board.isInBounds(getPosition() + direction)) {
					tempNode = board.get(getPosition() + direction);
					if (tempNode is Bridge3D) {
						if (board.isInBounds(tempNode.getPosition() + ((Bridge3D)tempNode).getDirection())
							&& board.get(tempNode.getPosition() + ((Bridge3D)tempNode).getDirection()) == this) {
							sum += ((Bridge3D)board.get (getPosition () + direction)).isDoubleBridge () ? 2 : 1;
						}
						if (board.isInBounds (tempNode.getPosition () - ((Bridge3D)tempNode).getDirection ())
						    && board.get (tempNode.getPosition () - ((Bridge3D)tempNode).getDirection ()) == this) {
							sum += ((Bridge3D)board.get (getPosition () + direction)).isDoubleBridge () ? 2 : 1;
						}
					}
				}
			}
			value = sum;
		}
	}
}