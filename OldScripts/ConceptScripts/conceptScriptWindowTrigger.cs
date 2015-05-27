using UnityEngine;
using System.Collections;

public class conceptScriptWindowTrigger : MonoBehaviour {
	
	public GameObject player;
	private GameObject[] everythings;
	private bool isEntered;

	// Use this for initialization
	void Start () {
		everythings = GameObject.FindGameObjectsWithTag ("DestroyedObject");
	}

	// When entering trigger collider
	void OnTriggerEnter(Collider player) {
		foreach(GameObject everything in everythings){
			Destroy (everything);
		}
		isEntered = true;
	}

	// Update is called once per frame
	void Update () {

		if (isEntered == true) {
			print ("isEntered == true");
		}

	}
}
