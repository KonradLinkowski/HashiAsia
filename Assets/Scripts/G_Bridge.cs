using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Bridge : MonoBehaviour {

	public G_Island Beginning { get; set; }

	public G_Island Ending { get; set; }

	public bool IsDouble { get; set; }

	LineRenderer lr;


	public void Initiate (G_Island beginning, G_Island ending) {
		if (!beginning.Connect (this)) {
			Beginning = beginning;
			Ending = ending;
			transform.position = beginning.transform.position;
			lr = GetComponent <LineRenderer> ();
			DrawLine (beginning.transform.position, ending.transform.position, Color.red);
		} else {
			DrawLine (beginning.transform.position, ending.transform.position, Color.blue);
		}
	}

	public void Connect (G_Island is1, G_Island is2) {

	}

	public void Delete (G_Island island) {
		if (island == Beginning) {
			Ending.RemoveBridge (this);
		} else {
			Beginning.RemoveBridge (this);
		}
		Destroy (gameObject);
	}

	private void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f) {
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.startColor = color;
		lr.endColor = color;
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
	}

	private void DrawLine2(Vector3 start, Vector3 end, Color color, float duration = 0.2f) {
		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.startColor = color;
		lr.endColor = color;
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
	}
}
