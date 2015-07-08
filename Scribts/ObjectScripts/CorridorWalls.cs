using UnityEngine;
using System.Collections;

public class CorridorWalls : ObjectParameter {

	// Arrays for the walls
	public GameObject[] wallsLeft;
	public GameObject[] wallsRight;

	// Heartbeat speed access
	public PlayerController playerController;

	// Array for Chair Thingies
	public GameObject[] chairThing;

	// Counter for Walls coming closer 
	private float wallCounter;
	private Vector3 wallMovement;
	private float xMovement;
	private float parameterDependence;

	// Use this for initialization
	void Start () {
		parameterDependence = 2;
		wallCounter = 0;
		print ("ChildObject || ObjectParemeter || is working and complete Intensity is " + completeIntensity);
	}
	
	// Update is called once per frame
	void Update () {
		if (wallCounter > 15) {
			playerController.Heart ();
		}
		// Because if initialized in Start(), sometimes the wrong variable is inherited ...
		if (wallCounter > 0.00001) {
			parameterDependence = (float)movementIntensity / 10000; // dependent on which "route" the user took
			xMovement = 0.00020f + parameterDependence;		 	   //the walls are moving slower or faster or not at all
		}

		/**************************
		| Walls coming closer     |
		**************************/
		if (wallCounter < 38) {
			foreach (GameObject wall in wallsLeft) {
				wall.transform.position += new Vector3 (xMovement, 0, 0);
			}
			foreach (GameObject wall in wallsRight) {
				wall.transform.position -= new Vector3 (xMovement, 0, 0);
			}
			//print ("Movement Intensity is " + movementIntensity);
			//print ("parameter dependence is " + parameterDependence);
			//print ("xMovement is " + xMovement);
			//print (wallCounter);
		}

		/**************************
		| Chairs appearing	      |
		**************************/
		if (wallCounter > 13.3) {
			if (movementIntensity < 10) {
				//print (wallCounter);
				foreach (GameObject chair in chairThing) {
					chair.SetActive (true);
					Rigidbody rb = chair.GetComponent <Rigidbody> ();
					if (wallCounter > 1000 && wallCounter < 1250) {
						rb.isKinematic = true;
					}
					if (wallCounter > 1250) {
						rb.isKinematic = false;
					}
				}
			}
			if (movementIntensity >= 10) {
				foreach (GameObject chair in chairThing) {
					//print ("Test");
					chair.SetActive (true);
					Rigidbody rb = chair.GetComponent <Rigidbody> ();
					Transform ts = chair.GetComponent <Transform> ();
					if (wallCounter > 820 && wallCounter < 1200) {
						rb.AddExplosionForce (50, ts.position*-1, 10);
					}
					if (wallCounter > 1200 && wallCounter < 1600) {
						rb.AddExplosionForce (70, ts.position*-1, 10);
					}
					if (wallCounter > 1650) {
						rb.AddExplosionForce (100, ts.position*-1, 10);
					}
				}
			}
		}
	

		if (wallCounter >= 40) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		wallCounter = wallCounter + 1 * Time.deltaTime;
	}

}
