using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator3D {
	public class Node3D {

		protected Vector3D position;

		private List <Vector3D> availableVectors = new List<Vector3D>();


		public Node3D(int x, int y, int z) {
			position = new Vector3D (x, y, z);
			fillList();
		}
		public Node3D(Vector3D position) {
			this.position = new Vector3D (position.x, position.y, position.z);
			fillList();
		}

		private void fillList () {
			availableVectors.Add(Vector3D.DOWN);
			availableVectors.Add(Vector3D.UP);
			availableVectors.Add(Vector3D.LEFT);
			availableVectors.Add(Vector3D.RIGHT);
			availableVectors.Add(Vector3D.BACK);
			availableVectors.Add(Vector3D.FORWARD);
		}

		public int getX() {
			return position.x;
		}
		public void setX(int x) {
			position.x = x;
		}
		public int getY() {
			return position.y;
		}
		public void setY(int y) {
			position.y = y;
		}
		public int getZ() {
			return position.z;
		}
		public void setZ(int z) {
			position.z = z;
		}
		public Vector3D getPosition () {
			return position;
		}

		public void setPosition (Vector3D position) {
			this.position.x = position.x;
			this.position.y = position.y;
			this.position.z = position.z;
		}

		public List<Vector3D> getAvailableDictions () {
			return availableVectors;
		}

		public Vector3D getDirections (int index) {
			return availableVectors [index];
		}

		public bool removeDirection (Vector3D dir) {
			return availableVectors.Remove(dir);
		}

		public int getDirectionsCount() {
			return availableVectors.Count;
		}
	}
}