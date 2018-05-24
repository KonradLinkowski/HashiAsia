using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator3D {
	public class Board3D {

		private Vector3D bounds;
		private Node3D[,,] grid;


		public Board3D(int x, int y, int z) {
			bounds = new Vector3D (x, y, z);
			grid = new Node3D [x, y, z];
		}

		public bool isInBounds (Vector3D position) {
			if (position.x < 0 || position.x >= bounds.x || position.y < 0 || position.y >= bounds.y || position.z < 0 || position.z >= bounds.z) {
				return false;
			}
			return true;
		}

		public bool canPlaceIsland (Vector3D position) {
			if (get(position) is Island3D) {
				return false;
			}
			foreach (Vector3D dir in Vector3D.directions) {
				Vector3D otherIsland = position + dir;
				if (isInBounds (otherIsland) && get (otherIsland) is Island3D) {
					return false;
				}
			}
			return true;
		}

		public void display () {
			string test = "";
			test += ("Board.display()\n");
			for (int g = 0; g < bounds.z; g++) {
				test += ("Layer = " + g + "\n");
				test += ("\\");
				for (int i = 0; i < bounds.x; i++) {
					test += (i % 10);
				}
				test += ("\n");
				for (int i = 0; i < bounds.y; i++) {
					test += (i % 10);
					for (int j = 0; j < bounds.x; j++) {
						if (grid[j, i, g] is Bridge3D) {
							if (((Bridge3D)(grid[j, i, g])).isDoubleBridge ()) {
								if (((Bridge3D)(grid[j, i, g])).getDirection () == Vector3D.DOWN
								   || ((Bridge3D)(grid[j, i, g])).getDirection () == Vector3D.UP) {
									test += ("!");
								} else if (((Bridge3D)(grid [j, i, g])).getDirection () == Vector3D.LEFT
									|| ((Bridge3D)(grid [j, i, g])).getDirection () == Vector3D.RIGHT) {
									test += ("=");
								} else {
									test += ("@");
								}
							} else {
								if (((Bridge3D)(grid [j, i, g])).getDirection () == Vector3D.DOWN
								    || ((Bridge3D)(grid [j, i, g])).getDirection () == Vector3D.UP) {
									test += ("|");
								} else if (((Bridge3D)(grid [j, i, g])).getDirection () == Vector3D.LEFT
								    || ((Bridge3D)(grid [j, i, g])).getDirection () == Vector3D.RIGHT) {
									test += ("-");
								} else {
									test += ("o");
								}
							}
						} else if (grid[j, i, g] is Island3D) {
							((Island3D)grid[j, i, g]).reValue (this);
							test += (((Island3D)grid[j, i, g]).getValue ());
						} else {
							test += (".");
						}
					}
					test += ("\n");
				}
				test += ("\n");
				Debug.Log (test);
			}
		}

		public bool canBuildBridge (Vector3D position) {
			if (get(position) is Bridge3D) {
				return false;
			}
			return true;
		}

		public int getX() {
			return bounds.x;
		}
		public void setX(int x) {
			bounds.x = x;
		}
		public int getY() {
			return bounds.y;
		}
		public void setY(int y) {
			bounds.y = y;
		}
		public int getZ() {
			return bounds.z;
		}
		public void setZ(int z) {
			bounds.z = z;
		}
		public Vector3D getSize () {
			return bounds;
		}
		public void setSize (Vector3D size) {
			bounds.x = size.x;
			bounds.y = size.y;
			bounds.z = size.z;
		}
		public Node3D get(int x, int y, int z) {
			return grid [x, y, z];
		}
		public void set(int x, int y, int z, Node3D node) {
			grid [x, y, z] = node;
		}
		public Node3D get(Vector3D position) {
			return grid [position.x, position.y, position.z];
		}
		public void set(Vector3D position, Node3D node) {
			grid [position.x, position.y, position.z] = node;
		}
		public void delete (int x, int y, int z) {
			grid [x, y, z] = null;
		}
		public void set (Node3D node) {
			grid [node.getX(), node.getY(), node.getZ()] = node;
		}

	}
}