using UnityEngine;
using System.Collections;

public class conecptScriptFarAwayTrigger : MonoBehaviour {

	public GameObject player;
	public GameObject dustStorm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter () {
		player.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
		Destroy (dustStorm);
	}
}
