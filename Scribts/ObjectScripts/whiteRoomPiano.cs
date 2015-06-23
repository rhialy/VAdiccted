using UnityEngine;
using System.Collections;

public class whiteRoomPiano : MonoBehaviour {

	public GameObject player;
	public GameObject textPiano;
	public Rigidbody[] pianoParts;

	private bool isPiano;


	// Use this for initialization
	void Start () {
		isPiano = false;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) {

		textPiano.SetActive (true);
		if (Input.GetButton ("Fire2")) {
			destroyPiano();
		}
	}

	void Update () {
		textPiano.SetActive (false);
	}

	private void destroyPiano () {

		foreach (Rigidbody pianoPart in pianoParts) {
			Rigidbody pianoPartRB = pianoPart.GetComponent <Rigidbody> ();
			pianoPartRB.isKinematic = false;
			/*float xD = Random.Range(0f, 20f);
			float yD = Random.Range(0f, 20f);
			float zD = Random.Range(0f, 20f);
			Vector3 direction = new Vector3 (xD, yD, zD);
			pianoPart.AddForce(direction, ForceMode.Impulse);*/
		}
	}
}
