using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator2D {
	public class Board {

		private Vector2D bounds;
		private Node[,] grid;


		public Board(int x, int y) {
			bounds = new Vector2D (x, y);
			grid = new Node [x, y];
		}

		public bool isInBounds (Vector2D position) {
			if (position.x < 0 || position.x >= bounds.x || position.y < 0 || position.y >= bounds.y) {
				return false;
			}
			return true;
		}

		public bool canPlaceIsland (Vector2D position) {
			if (get(position) is Island) {
				return false;
			}
			foreach (Vector2D dir in Vector2D.directions) {
				Vector2D otherIsland = position + dir;
				if (isInBounds (otherIsland) && get (otherIsland) is Island) {
					return false;
				}
			}
			return true;
		}

		public void display () {
			string test = "";
			test += ("Board.display()\n");
			test += ("\\");
			for (int i = 0; i < bounds.x; i++) {
				test += (i % 10);
			}
			test += ("\n");
			for (int i = 0; i < bounds.y; i++) {
				test += (i % 10);
				for (int j = 0; j < bounds.x; j++) {
					if (grid [j, i] is Bridge) {
						if (((Bridge)(grid [j, i])).isDoubleBridge ()) {
							if (((Bridge)(grid [j, i])).getDirection() == Vector2D.DOWN
								|| ((Bridge)(grid [j, i])).getDirection() == Vector2D.UP) {
								test += ("!");
							} else {
								test += ("=");
							}
						} else {
							if (((Bridge)(grid [j, i])).getDirection() == Vector2D.DOWN
								|| ((Bridge)(grid [j, i])).getDirection() == Vector2D.UP) {
								test += ("|");
							} else {
								test += ("-");
							}
						}
					} else if (grid [j, i] is Island) {
						((Island)grid[j, i]).reValue(this);
						test += (((Island)grid[j, i]).getValue());
					} else {
						test += (".");
					}
				}
				test += ("\n");
			}
			test += ("\n");
			Debug.Log (test);
		}

		public bool canBuildBridge (Vector2D position) {
			if (get(position) is Bridge) {
				return false;
			}
			return true;
		}

		public int getX() {
			return (int)bounds.x;
		}
		public void setX(int x) {
			bounds.x = x;
		}
		public int getY() {
			return (int)bounds.y;
		}
		public void setY(int y) {
			bounds.y = y;
		}
		public Vector2D getSize () {
			return bounds;
		}
		public void setSize (Vector2D size) {
			bounds.x = size.x;
			bounds.y = size.y;
		}
		public Node get(int x, int y) {
			return grid [x, y];
		}
		public void set(int x, int y, Node node) {
			grid [x, y] = node;
		}
		public Node get(Vector2D position) {
			return grid [(int)position.x, (int)position.y];
		}
		public void set(Vector2D position, Node node) {
			grid [(int)position.x, (int)position.y] = node;
		}
		public void delete (int x, int y) {
			grid [x, y] = null;
		}
		public void set (Node node) {
			grid [node.getX(), node.getY()] = node;
		}

	}
}