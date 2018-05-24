using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	public GameObject lineRender;

	bool isMoved;
	GameObject grabbedObject;

	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			GrabIsland(Input.GetTouch (0).position);
		}
		if (Input.GetMouseButtonDown (0) && !isMoved) {
			grabbedObject = GrabIsland(Input.mousePosition);
			if (grabbedObject != null) {
				isMoved = true;
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			isMoved = false;
			if (grabbedObject != null) {
				GameObject tempGrabbed = GrabIsland (Input.mousePosition);
				if (tempGrabbed != null) {
					if (!grabbedObject.GetComponent <G_Island> ().IsConnected (tempGrabbed.GetComponent <G_Island> ())) {
						GameObject temp = Instantiate (lineRender);
						temp.GetComponent <G_Bridge> ().Initiate (grabbedObject.GetComponent <G_Island> (), tempGrabbed.GetComponent <G_Island> ());
					} else {
						grabbedObject.GetComponent <G_Island> ().Connect (gameObject.GetComponent<G_Bridge>());
					}
				} else {
					grabbedObject = null;
				}
			} else {
				grabbedObject = null;
			}
		}
	}

	GameObject GrabIsland (Vector3 mousePosition) {
		RaycastHit hitInfo;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (mousePosition), out hitInfo, 30.0f)) {
			Debug.Log (hitInfo.collider.gameObject.GetComponent<G_Island> ().Value);
			return hitInfo.collider.gameObject;
		}
		return null;
	}
}
