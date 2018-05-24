using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator3D {
	public class Generator3D {


		public Generator3D (long seed) {
			Random.InitState ((int)seed);
		}

		public List <Island3D> generateIslands (int x, int y, int z, int number) {
			Board3D board = generate (x, y, z, number);
			List <Island3D> islands = new List <Island3D> ();
			for (int i = 0; i < x; i++) {
				for (int j = 0; j < y; j++) {
					for (int k = 0; k < z; k++) {
						if (board.get(i, j, k) is Island3D) {
							islands.Add (board.get (i, j, k) as Island3D);
							((Island3D)board.get(i, j, k)).reValue (board);
						}
					}
				}
			}
			board.display ();
			return islands;
		}

		public Board3D generate (int x, int y, int z, int number) {
			Board3D board = new Board3D (x, y, z);
			List <Island3D> islands = new List<Island3D> ();
			islands.Add(new Island3D (Random.Range(0, x), Random.Range(0, y), Random.Range(0, z)));
			board.set(islands[0]);
			int i = 0;
			Island3D firstNode;
			Vector3D randomDirection;
			while (i < number - 1) {
				if (islands.Count == 0) {
					return generate (x, y, z, number);
				}
				firstNode = islands[Random.Range(0, islands.Count)];
				if (firstNode.getDirectionsCount() == 0) {
					islands.Remove(firstNode);

					continue;
				}
				randomDirection = firstNode.getDirections(Random.Range(0, firstNode.getDirectionsCount()));
				if (generateNewIsland (board, islands, randomDirection, firstNode.getPosition())) {
					i++;
					continue;
				} else {
					firstNode.removeDirection(randomDirection);
					continue;
				}
			}
			islands.Clear();
			return board;
		}

		private bool generateNewIsland (Board3D board, List<Island3D> islands, Vector3D direction, Vector3D origin) {
			Vector3D current = origin + direction;
			Vector3D lastPossible = null;
			if (!board.isInBounds(current)) {
				return false;
			}
			if (!board.canBuildBridge(current)) {
				return false;
			}
			while (true) {
				current += direction;
				if (!board.isInBounds(current)) {
					return false;
				}
				if (board.canPlaceIsland(current)) {
					lastPossible = current;
					if (board.canBuildBridge(current)) {
						if (Random.Range (0, 2) == 1 ? true : false) {
							continue;
						} else {
							createIsland(board, origin, lastPossible, islands, direction);
							return true;
						}
					} else {
						createIsland(board, origin, lastPossible, islands, direction);
						return true;
					}
				} else if (board.get(current) is Island3D) {
					return false;
				} else if (board.canBuildBridge(current)) {
					continue;
				} else if (lastPossible != null){
					createIsland (board, origin, lastPossible, islands, direction);
					return true;
				} else {
					return false;
				}
			}
		}

		private void createIsland (Board3D board, Vector3D beginning,
			Vector3D lastIsland, List <Island3D> islands, Vector3D direction) {
			Island3D tempIsland;
			updateBoard(board, beginning, lastIsland, direction);
			tempIsland = new Island3D (lastIsland);
			board.set(tempIsland);
			islands.Add(tempIsland);
		}

		private void updateBoard (Board3D board, Vector3D startPoint, Vector3D endPoint, Vector3D direction) {
			bool isDouble = Random.Range (0, 2) == 1 ? true : false;
			if (direction == Vector3D.UP) {
				for (int i = startPoint.y - 1; i >= endPoint.y; i--) {
					board.set(new Bridge3D (startPoint.x, i, startPoint.z, isDouble, direction));
				}
			} else if (direction == Vector3D.DOWN) {
				for (int i = startPoint.y + 1; i <= endPoint.y; i++) {
					board.set(new Bridge3D (startPoint.x, i, startPoint.z, isDouble, direction));
				}
			} else if (direction == Vector3D.LEFT) {
				for (int i = startPoint.x - 1; i >= endPoint.x; i--) {
					board.set(new Bridge3D (i, startPoint.y, startPoint.z, isDouble, direction));
				}
			} else if (direction == Vector3D.RIGHT) {
				for (int i = startPoint.x + 1; i <= endPoint.x; i++) {
					board.set(new Bridge3D (i, startPoint.y, startPoint.z, isDouble, direction));
				}
			} else if (direction == Vector3D.FORWARD) {
				for (int i = startPoint.z - 1; i >= endPoint.z; i--) {
					board.set(new Bridge3D (startPoint.x, startPoint.y, i, isDouble, direction));
				}
			} else {
				for (int i = startPoint.z + 1; i <= endPoint.z; i++) {
					board.set(new Bridge3D (startPoint.x, startPoint.y, i, isDouble, direction));
				}
			} 
		}
	}
}