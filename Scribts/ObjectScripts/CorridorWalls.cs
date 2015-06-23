using UnityEngine;
using System.Collections;

public class CorridorWalls : ObjectParameter {

	// Arrays for the walls
	public GameObject[] wallsLeft;
	public GameObject[] wallsRight;

	// Counter for Walls coming closer 
	private int wallCounter;
	private int progressFinish;
	private Vector3 wallMovement;
	private float xMovement;
	private float parameterDependence;

	// Use this for initialization
	void Start () {
		wallCounter = 0;
		progressFinish = 11375; // Framerate is 175 and the scene should last approx. 65 sec. -> 65*175=11375
		parameterDependence = movementIntensity / 10000; // dependent on which "route" the user took 
		xMovement = 0.00030f + parameterDependence;		 //the walls are moving slower or faster or not at all
	}
	
	// Update is called once per frame
	void Update () {
		if (wallCounter < 11375) {
			foreach (GameObject wall in wallsLeft) {
				wall.transform.position += new Vector3 (xMovement, 0, 0);
			}
			foreach (GameObject wall in wallsRight) {
				wall.transform.position -= new Vector3 (xMovement, 0, 0);
			}
			wallCounter++;
			//print (wallCounter);
			//print (xMovement);
		}
		if (wallCounter >= 11375) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
}
