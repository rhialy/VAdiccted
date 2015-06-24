using UnityEngine;
using System.Collections;

public class CorridorLight : LightParameter {

	// Arrays for the lights
	public Light[] chandeliers;

	// Variable for velocity for Helligkeit()
	private int velocity = 700;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// If Drug is LSD, soul parameter is not good and third Question is not quiet
		if(LSD == true && soulGood == false && !(thirdQuestion == 2)){
			foreach (Light chandelier in chandeliers) {
				OnAndOf(chandelier);
			}
		}

		foreach (Light chandelier in chandeliers) {
			Helligkeit(velocity, true, 0, 100, chandelier);
			Farbe (velocity, true, 0, 100, chandelier);
		}

	}
}
