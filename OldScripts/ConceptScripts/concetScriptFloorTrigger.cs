using UnityEngine;
using System.Collections;

public class concetScriptFloorTrigger : MonoBehaviour {

	public GameObject Player;
	public GameObject floorLight;

	private GameObject[] particleSystems;
	private float lightFlicker;
	private bool isFlickering;
	// Use this for initialization
	void Start () {
		particleSystems = GameObject.FindGameObjectsWithTag ("Particle System");
		isFlickering = false;
	}

	// when entering trigger collider
	void OnTriggerEnter(Collider Player) {
		foreach (GameObject particleSystem in particleSystems) {
			Destroy (particleSystem);
		}
		isFlickering = true;
		Rigidbody prb = Player.GetComponent<Rigidbody> ();
		prb.mass = 1.0f;
		PlayerController.gravity = 9.81f;
	}

	// Update is called once per frame
	void Update () {
		if (isFlickering) {
			lightFlicker = Random.value;
			
			if (lightFlicker > 0.5) {
				floorLight.SetActive(true);
			}
			if (lightFlicker < 0.5) {
				floorLight.SetActive(true);
			}
		}
	}
}
