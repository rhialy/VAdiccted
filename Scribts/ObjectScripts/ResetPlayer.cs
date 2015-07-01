using UnityEngine;
using System.Collections;

public class ResetPlayer : LightParameter {

	public GameObject player;

	private float xPosition;
	private float yPosition;

	private int progressCounter;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) {

		// Resets the player's position, so that the corridor seems endless
		// the z-axis reset is the same length as the player's distance to 
		// the next lamp at the moment of reset, so that there is no 
		// stutter (or as less as possible) in the reset frame
		Transform playerTransform = player.GetComponent <Transform> ();
		xPosition = playerTransform.position.x;
		yPosition = playerTransform.position.y;
		player.transform.position = new Vector3 (xPosition, yPosition, -3.39f);


		progressCounter = progressCounter + 1;
		//print (progressCounter);
		if (progressCounter >= 2) {
			//TODO: Add Sound File (Laughing | Whispering | smthng creepy?)
		}
	}
}
