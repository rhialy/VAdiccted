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
		Transform playerTransform = player.GetComponent <Transform> ();
		xPosition = playerTransform.position.x;
		yPosition = playerTransform.position.y;
		player.transform.position = new Vector3 (xPosition, yPosition, 0f);


		progressCounter = progressCounter + 1;
		print (progressCounter);
		if (progressCounter >= 9) {

		}
	}
}
