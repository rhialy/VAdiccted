using UnityEngine;
using System.Collections;

public class BreakableWall : MonoBehaviour {

	public GameObject Player;
	public GameObject breakableWall;
	public GameObject randomizedObject;
	public GameObject OtherRandomizedObject;
	public GameObject dirLightDark;
	public GameObject dirLightWhite;

	private bool isTriggered;
	private float randomCounter;

	// Use this for initialization
	void Start () {
		isTriggered = false;
	}

	// Update is called once per frame
	void Update(){
		if (isTriggered == true) {
			breakableWall.transform.position += new Vector3 (0.0f, 0.1f, 0.0f);
		}
		if (breakableWall.transform.position.y >= 6.0f) {
			isTriggered = false;
		}
	}

	void OnTriggerEnter(Collider Player){
		isTriggered = true;
		randomCounter = Random.value;
		if (randomCounter < 0.5) {
			randomizedObject.SetActive (true);
			dirLightDark.SetActive(true);
		}
		if (randomCounter > 0.5){
			OtherRandomizedObject.SetActive (true);
			dirLightDark.SetActive(true);
		}
		//breakableWall.transform.position = new Vector3 (-8.5f, 5.51f, -11.14f);
	}
}