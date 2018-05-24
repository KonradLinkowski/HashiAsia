using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator2D {
	public class Island : Node {

		private int value;
		public Board[] boards = new Board[4];

		public Island(int x, int y) : base (x, y) {
		}

		public Island (Vector2D position) : base (position) {
		}

		public void setValue (int value) {
			this.value = value;
		}
		public int getValue () {
			return value;
		}

		public void reValue (Board board) {
			int sum = 0;
			Node tempNode;
			foreach (Vector2D direction in Vector2D.directions) {
				if (board.isInBounds(getPosition() + direction)) {
					tempNode = board.get(getPosition() + direction);
					if (tempNode is Bridge) {
						if (board.isInBounds(tempNode.getPosition() + ((Bridge)tempNode).getDirection())
							&& board.get(tempNode.getPosition() + ((Bridge)tempNode).getDirection()) == this) {
							sum += ((Bridge)board.get (getPosition () + direction)).isDoubleBridge () ? 2 : 1;
						}
						if (board.isInBounds (tempNode.getPosition () - ((Bridge)tempNode).getDirection ())
						    && board.get (tempNode.getPosition () - ((Bridge)tempNode).getDirection ()) == this) {
							sum += ((Bridge)board.get (getPosition () + direction)).isDoubleBridge () ? 2 : 1;
						}
					}
				}
			}
			value = sum;
		}
	}
}