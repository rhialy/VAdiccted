using UnityEngine;
using System.Collections;

public class whiteRoomPiano : ObjectParameter {

	public GameObject player;
	public GameObject textPiano;
	public Rigidbody[] pianoParts;
	public GameObject room;
	public GameObject teddys;

	private bool isPiano;
	private bool destroyed;
	private float pCounter;
	private float dCounter;

	// Use this for initialization
	void Start () {
		pCounter = 80;
		isPiano = false;
		textPiano.SetActive (false);
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) {

		// TODO: Audio File: "Möchtest du vielleicht Klavier spielen?"

		isPiano = true;

		if (Input.GetButton ("Fire2")) {
			destroyPiano ();
		}
		// For Debugging purposes:
		if (Input.GetKey ("e")) {
			destroyPiano ();
		}
	}

	void Update () {

		pCounter++;
		// This script should originally be intended to use raycasts, but we figured a simple trigger collider
		// would be easier to implement. On top of that using raycasts with the dependent hitter for 
		// an array of objects isn't working properly and uses a load of processing power.
		if (destroyed == false) {
			if (isPiano == true) {
				textPiano.SetActive (true);
			}
		} else if (destroyed == true) {
			dCounter = dCounter + 1 * Time.deltaTime;
		}

		if (pCounter >= 80) {
			isPiano = false;
			textPiano.SetActive (false);
			pCounter = 0;
		}

		// The piano is the trigger for setting the player in a "room", while the falling script acts independently
		if ((int)dCounter == 2) {
			player.transform.position = new Vector3 (-7, 2, 0);
			room.SetActive (true);
			teddys.transform.position = new Vector3 (45, 1, 1);
		}
		print ("dCounter is " + dCounter);
	}

	private void destroyPiano () {
		destroyed = true;
		if (completeIntensity > 11) {
			foreach (Rigidbody pianoPart in pianoParts) {
				Rigidbody pianoPartRB = pianoPart.GetComponent <Rigidbody> ();
				pianoPartRB.isKinematic = false;
			}
		} else if (completeIntensity < 11) {
			//TODO: Sound File?
		}
	}
}
