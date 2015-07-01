using UnityEngine;
using System.Collections;

public class CarEnd : MonoBehaviour {

	public GameObject playerCamera;
	public GameObject LSDCamera;
	public GameObject player;
	public GameObject[] cars;
	public GameObject endCar;
	public Light uLt;
	public Light dLt;
	public Light fLt;
	public GameObject highway;
	public GameObject forest;

	private float endCounter;
	private float carCounter;
	private float rotateCounter;
	private float transitionCounter;
	private float deadFloat;
	private float[] xPos;
	private float[] yPos;
	private Vector3[] resetPos;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < cars.Length; i++) {
			xPos[i] = cars[i].transform.position.x;
			yPos[i] = cars[i].transform.position.y;
			resetPos[i] = new Vector3 (xPos[i], yPos[i], 30);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (endCounter > 10) {
			PlayerController.controllable = false;
		}
		if (endCounter > 10 && endCounter < 13) {
			if (transitionCounter >= 0 && transitionCounter < 3.0) {
				dLt.intensity = dLt.intensity + 0.05f;
				uLt.intensity = uLt.intensity + 0.25f;
				uLt.range = uLt.range + 120;
				fLt.intensity = fLt.intensity + 0.14f;
				fLt.range = fLt.range + 80;
			}
			if (transitionCounter >= 2.2 && transitionCounter < 3.0) {
				playerCamera.SetActive(false);
				LSDCamera.SetActive(true);
			}
			if (transitionCounter >= 2.9 && transitionCounter < 3.2) {
				float yPos = player.transform.position.y;
				player.transform.position = new Vector3(4.5f, yPos, 27.8f);
				highway.SetActive(true);
				forest.SetActive(false);
				foreach (GameObject car in cars) {
					car.SetActive(true);
				}
			}
			if(transitionCounter >= 2.88 && transitionCounter < 6) {
				playerCamera.SetActive(true);
				LSDCamera.SetActive(false);
			}
			if (transitionCounter >= 2.78) {
				if (uLt.intensity > 1) {
					dLt.intensity = dLt.intensity - 0.2f;
					uLt.intensity = uLt.intensity - 0.2f;
					uLt.range = 27;
					fLt.intensity = fLt.intensity - 0.2f;
					fLt.range = 27;
				}
			}
			print ("transition counter is " + transitionCounter);
			transitionCounter = transitionCounter + 1 * Time.deltaTime;

		}
		if (endCounter > 12.7 && endCounter < 18) {
			for (int i = 0; i < cars.Length; i++) {

				float carMovement = Random.Range (0.1f, 0.3f);
				cars [i].transform.position -= new Vector3 (0f, 0f, carMovement);
				
				if (carCounter > 450 && carCounter < 550) {
					cars [i].SetActive (false);
				}
				if (carCounter > 600) {
					cars [i].SetActive (true);
					//cars [i].transform.position = resetPos [i];
				}
			}
			carCounter = carCounter + 1 * Time.deltaTime;
		}
		if (endCounter > 13) {
			player.transform.LookAt(endCar.transform.position);
			endCar.transform.position += new Vector3 (0f, 0f, 0.5f);
		}
		if (endCar.transform.position.z >= player.transform.position.z - 10) {
			uLt.intensity = 8;
		}
		if (endCar.transform.position.z >= player.transform.position.z + 15) {
			uLt.intensity = 1;
			if (rotateCounter < 90) {
				deadFloat = deadFloat + 1;
				rotateCounter = rotateCounter + 1;
			}
			Vector3 deadRotation = new Vector3 (deadFloat, 0, 0);
			//if (rotateCounter < 90) {
				player.transform.Rotate (deadRotation);
			//}
		}
		if (endCar.transform.position.z >= player.transform.position.z + 150) {
			uLt.intensity = uLt.intensity - 0.2f;
			dLt.intensity = dLt.intensity - 0.2f;
			fLt.intensity = fLt.intensity - 0.2f;
		}
		if (endCar.transform.position.z >= player.transform.position.z + 300) {
			uLt.color = Color.black;
			dLt.color = Color.black;
			fLt.color = Color.black;
		}
		if (carCounter > 650) {
			carCounter = 0;
		}
		//print ("carCounter is " + carCounter);
		endCounter = endCounter + 1 * Time.deltaTime;
	}
}
