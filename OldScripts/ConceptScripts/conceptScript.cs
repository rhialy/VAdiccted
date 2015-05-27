using UnityEngine;
using System.Collections;

public class conceptScript : MonoBehaviour {

	//Step 1 public variables:
	public GameObject triggeredObject;
	public GameObject spotLight;
	public GameObject windowLight1;
	public float timeLeft;
	//Step 2 public variables:
	public float timeLeftStep2;
	public GameObject player;


	//Step 1 private variables:
	private Rigidbody rb;
	private float force;
	private bool timeUp;
	private float lightFlicker;
	//Step 2 private variables:
	private bool timeUpSecond;
	//Step 2 private Arrays:
	private GameObject[] particleSystems;
	private GameObject[] objectsLater;

	// Use this for initialization
	void Start () {
		force = 5.0f;
		triggeredObject.AddComponent<Rigidbody> ();
		// Inizialization for Step 2:
		particleSystems = GameObject.FindGameObjectsWithTag ("Particle System");
		foreach (GameObject particleSystem in particleSystems) {
			particleSystem.SetActive (false);
		}
		objectsLater = GameObject.FindGameObjectsWithTag ("DestroyedLater");
	}
	
	// Update is called once per frame
	void Update () {

		//Initialziation of Step 1:
		if (timeLeft > 1) {
			timeLeft = timeLeft - Time.deltaTime;
		}
		if (timeLeft < 1) {
			timeUp = true;
		}
		if (timeUp == true) {
			// Activation of Step 1:
			//letting an object stagger
			rb = triggeredObject.GetComponent<Rigidbody> ();
			rb.AddForce (transform.forward * force, ForceMode.Force);

			//changing light color
			lightFlicker = Random.value;

			if(lightFlicker > 0.5){
				spotLight.SetActive(true);
				windowLight1.SetActive(true);
			}
			if(lightFlicker < 0.5){
				spotLight.SetActive(false);
				windowLight1.SetActive(false);
			}
			foreach (GameObject particleSystem in particleSystems) {
				particleSystem.SetActive (true);
			}


			// Initialization of Step 2:
			if(timeLeftStep2 > 1){
				timeLeftStep2 = timeLeftStep2 - Time.deltaTime;
			}
			if(timeLeftStep2 < 1){
				timeUpSecond = true;
			}
			//Activation of Step 2:
			if(timeUpSecond == true){
				foreach (GameObject objectLater in objectsLater) {
					Destroy (objectLater);
					print ("second time is up");
				}
				Rigidbody prb = player.GetComponent<Rigidbody>();
				prb.mass = 0.1f;
				PlayerController.gravity = 1.0f;
			}

			//print for debugging
			print ("time is up");
		}
	}
}
