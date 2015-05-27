using UnityEngine;
using System.Collections;

public class SimulationInitializator : MonoBehaviour {

	public GameObject activatedObject;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnTriggerEnter () {
		activatedObject.SetActive (true);
	}
}
