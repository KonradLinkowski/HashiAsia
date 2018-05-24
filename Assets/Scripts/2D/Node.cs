using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator2D {
	public class Node {

		protected Vector2D position;

		private List <Vector2D> availableVectors = new List<Vector2D>();


		public Node(int x, int y) {
			position = new Vector2D (x, y);
			fillList();
		}
		public Node(Vector2D position) {
			this.position = new Vector2D (position.x, position.y);
			fillList();
		}

		private void fillList () {
			availableVectors.Add(Vector2D.DOWN);
			availableVectors.Add(Vector2D.UP);
			availableVectors.Add(Vector2D.LEFT);
			availableVectors.Add(Vector2D.RIGHT);
		}

		public int getX() {
			return (int)position.x;
		}
		public void setX(int x) {
			position.x = x;
		}
		public int getY() {
			return (int)position.y;
		}
		public void setY(int y) {
			position.y = y;
		}

		public Vector2D getPosition () {
			return position;
		}

		public void setPosition (Vector2D position) {
			this.position.x = position.x;
			this.position.y = position.y;
		}

		public List<Vector2D> getAvailableDictions () {
			return availableVectors;
		}

		public Vector2D getDirections (int index) {
			return availableVectors [index];
		}

		public bool removeDirection (Vector2D dir) {
			return availableVectors.Remove(dir);
		}

		public int getDirectionsCount() {
			return availableVectors.Count;
		}
	}
}