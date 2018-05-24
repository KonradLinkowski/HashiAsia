using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Konrad.Generator2D;
using Konrad.Generator3D;
using UnityEngine.UI;
using System;
public class Creator : MonoBehaviour {

	public GameObject island;
	public GameObject bridge;

	public InputField xField;
	public InputField yField;
	public InputField zField;
	public InputField numberField;

	public GameObject[] numberModels;

	public List <GameObject> g_islands = new List<GameObject> ();

	private const float constOfWidth = 1.2f;
	private GameObject[] table;
	void Start () {
	}

	public void Generate () {
		for (int i = 0; i < g_islands.Count; i++) {
			Destroy (g_islands [i]);
		}
		g_islands.Clear ();
		Camera.main.orthographicSize = constOfWidth * int.Parse (yField.text) / 2 + constOfWidth / 2;
		Camera.main.transform.position = new Vector3 (constOfWidth * int.Parse (xField.text) / 2,
			constOfWidth * int.Parse (yField.text) / 2 - constOfWidth / 2, -20);
		test2D (int.Parse (xField.text), int.Parse (yField.text), int.Parse (numberField.text));
	}

	private void test2D (int x, int y, int number) {
		Generator gen = new Generator (DateTime.Now.Millisecond);
		List <Island> islands = gen.generateIslands (x, y, number);
		GameObject test, objectModel;
		for (int i = 0; i < islands.Count; i++) {
			test = Instantiate (island, new Vector3 (islands [i].getX() * constOfWidth, islands [i].getY() * constOfWidth, 0), Quaternion.identity) as GameObject;
			test.GetComponent <G_Island> ().Value = islands [i].getValue();
			objectModel = Instantiate (numberModels [islands [i].getValue()],
				new Vector3 (islands [i].getX() * constOfWidth, islands [i].getY() * constOfWidth, 0),Quaternion.Euler(new Vector3 (-90, 180, 0))) as GameObject;

			objectModel.transform.SetParent (test.transform);
			g_islands.Add (test);
		}
	}

	private void test3D (int x, int y, int z, int number) {
		Generator3D gen = new Generator3D (DateTime.Now.Millisecond);
		List <Island3D> islands = gen.generateIslands (x, y, z, number);
		List <GameObject> g_islands = new List<GameObject> ();
		GameObject test, objectModel;
		for (int i = 0; i < islands.Count; i++) {
			test = Instantiate (island, new Vector3 (islands [i].getX(), islands [i].getY(), islands [i].getZ()), Quaternion.identity) as GameObject;
			test.GetComponent <G_Island> ().Value = islands [i].getValue();
			objectModel = Instantiate (numberModels [islands [i].getValue()],
				new Vector3 (islands [i].getX(), islands [i].getY(), islands [i].getZ()), Quaternion.Euler(new Vector3 (-90, 0, 0))) as GameObject;

			objectModel.transform.SetParent (test.transform);
			g_islands.Add (test);
		}
	}
}
