using UnityEngine;
using System.Collections;

public class OnTriggerSetActive : MonoBehaviour {
	
	public GameObject activatedGameObject;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) {
		activatedGameObject.SetActive (true);
		print ("trigger funktioniert");
	}
}
