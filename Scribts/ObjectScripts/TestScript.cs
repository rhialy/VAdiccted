using UnityEngine;
using System.Collections;

public class TestScript : ObjectParameter {

	public GameObject movingObject;

	private int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(counter < 500) {
			movingObject.transform.position += new Vector3(0.01f, 0, 0);
			counter++;
		}
	}
}
