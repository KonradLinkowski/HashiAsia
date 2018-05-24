using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Konrad.Generator2D {
	public class Generator {


		public Generator (long seed) {
			Random.InitState ((int)seed);
		}

		public List <Island> generateIslands (int x, int y, int number) {
			Board board = generate2D (x, y, number);
			List <Island> islands = new List <Island> ();
			for (int i = 0; i < x; i++) {
				for (int j = 0; j < y; j++) {
					if (board.get(i, j) is Island) {
						islands.Add (board.get (i, j) as Island);
						((Island)board.get(i, j)).reValue (board);
					}
				}
			}
			board.display ();
			return islands;
		}

		public Board generate2D (int x, int y, int number) {
			Board board = new Board (x, y);
			List <Island> islands = new List<Island> ();
			islands.Add(new Island (Random.Range(0, x), Random.Range(0, y)));
			board.set(islands[0]);
			int i = 0;
			Island firstNode;
			Vector2D randomDirection;
			while (i < number - 1) {
				if (islands.Count == 0) {
					return generate2D (x, y, number);
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

		private bool generateNewIsland (Board board, List<Island> islands, Vector2D direction, Vector2D origin) {
			Vector2D current = origin + direction;
			Vector2D lastPossible = null;
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
				} else if (board.get(current) is Island) {
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

		private void createIsland (Board board, Vector2D beginning,
			Vector2D lastIsland, List <Island> islands, Vector2D direction) {
			Island tempIsland;
			updateBoard(board, beginning, lastIsland, direction);
			tempIsland = new Island (lastIsland);
			//board.get(beginning).boards [
			//TODO
			board.set(tempIsland);
			islands.Add(tempIsland);
		}

		private void updateBoard (Board board, Vector2D startPoint, Vector2D endPoint, Vector2D direction) {
			bool isDouble = Random.Range (0, 2) == 1 ? true : false;
			if (direction == Vector2D.UP) {
				for (int i = (int)startPoint.y - 1; i >= (int)endPoint.y; i--) {
					board.set(new Bridge ((int)startPoint.x, i, isDouble, direction));
				}
			} else if (direction == Vector2D.DOWN) {
				for (int i = (int)startPoint.y + 1; i <= (int)endPoint.y; i++) {
					board.set(new Bridge ((int)startPoint.x, i, isDouble, direction));
				}
			} else if (direction == Vector2D.LEFT) {
				for (int i = (int)startPoint.x - 1; i >= (int)endPoint.x; i--) {
					board.set(new Bridge (i, (int)startPoint.y, isDouble, direction));
				}
			} else {
				for (int i = (int)startPoint.x + 1; i <= (int)endPoint.x; i++) {
					board.set(new Bridge (i, (int)startPoint.y, isDouble, direction));
				}
			}
		}
	}
}