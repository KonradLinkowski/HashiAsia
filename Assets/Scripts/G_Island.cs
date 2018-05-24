using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Island : MonoBehaviour {

	public List <G_Bridge> bridges = new List <G_Bridge> ();

	public int Value {
		get {
			return this.value;
		}
		set {
			this.value = value;

		}
	}
	private int value;


	void Start () {
		bridges.Clear ();
	}

	void Update() {
		//Quaternion targerRotation = Quaternion.LookRotation (Camera.main.transform.position - transform.position);
		//transform.rotation = Quaternion.Slerp (transform.rotation, targerRotation, 5 * Time.deltaTime);
	}

	public bool IsConnected (G_Island island) {
		foreach (var bridge in bridges) {
			if (bridge.Beginning == this) {
				if (bridge.Ending == island) {
					return true;
				}
				return false;
			} else {
				if (bridge.Beginning == island) {
					return true;
				}
				return false;
			}
		}
		return false;
	}

	public void RemoveBridge (G_Bridge bridge) {
		bridges.Remove (bridge);
	}

	public bool Connect (G_Bridge bridge) {
		if (bridges.Contains (bridge)) {
			if (!bridge.IsDouble) {
				return true;
			} else {
				bridges.Remove (bridge);
				bridge.Delete (this);
				return false;
			}
		} else {
			bridges.Add (bridge);
			return false;
		}
	}
}
