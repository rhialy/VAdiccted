using UnityEngine;
using System.Collections;

public class whiteRoomResetter : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) {
		player.transform.position = new Vector3 (0, 20, 0);
	}
}
