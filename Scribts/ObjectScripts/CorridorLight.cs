using UnityEngine;
using System.Collections;

public class CorridorLight : LightParameter {

	// Arrays for the lights
	public Light[] chandeliers;

	// LUTs for Image effects
	public GameObject cameraLSDGood;
	public GameObject cameraLSDBad;
	public GameObject cameraQuiet;
	public GameObject cameraNormal;

	// Variable for velocity for Helligkeit()
	private float velocity = 6;
	private float CLcounter;

	// Use this for initialization
	void Start () {
		//print ("Light Parameter working? :: LSD is " + LSD);
	}
	
	// Update is called once per frame
	void Update () {
		//print ("CorridorLight Complete Intensity: " + completeIntensity);
		if(completeIntensity > 5 && completeIntensity <= 9){
			foreach (Light chandelier in chandeliers) {
				OnAndOf(chandelier);
			}
		}

		foreach (Light chandelier in chandeliers) {
			Helligkeit(velocity, true, 0, 100, chandelier);
			Farbe (velocity, true, 0, 100, chandelier);
		}

		CLcounter = CLcounter + 1 * Time.deltaTime;

		if (CLcounter > 20) {
			//print ("test");
			//cameraLSDGood.SetActive(true);
			//cameraNormal.SetActive(false);
			if (completeIntensity >= 12) {
				cameraLSDGood.SetActive(true);
				cameraNormal.SetActive(false);
			}
			if (completeIntensity >= 9 && completeIntensity <= 11) {
				cameraLSDBad.SetActive(true);
				cameraNormal.SetActive(false);
			}
			if (completeIntensity <= 5 && completeIntensity <= 8) {
				cameraQuiet.SetActive(true);
				cameraNormal.SetActive(false);
			}
		}
	}
}
