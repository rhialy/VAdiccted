using UnityEngine;
using System.Collections;

public class whiteRoomFalling : ObjectParameter {

	public GameObject[] fallingObjects;
	public GameObject ground;
	public GameObject earth;
	private float fCounter;

	// Use this for initialization
	void Start () {
		fCounter = 0;
		foreach (GameObject fallingObject in fallingObjects) {
			fallingObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject fallingObject in fallingObjects) {
			if (fCounter > 16) {
				fallingObject.SetActive(true);
			}
			if (fCounter > 20) {
				ground.SetActive(false);
				Vector3 objectRotation = new Vector3 (20, 0, 0);
				fallingObject.transform.Rotate (objectRotation);
				if (sizeChangeIntensity > 10) {
					fallingObject.transform.localScale += new Vector3 (0.001f, 0.001f, 0.001f);
				}
				if (sizeChangeIntensity < 10) {
					fallingObject.transform.localScale -= new Vector3 (0.001f, 0.001f, 0.001f);
				}
			}
			earth.transform.position = new Vector3 (0f, -242f, -130.8f);
		}
		fCounter = fCounter + 1 * Time.deltaTime;
		if (fCounter > 36) {
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}
