using UnityEngine;
using System.Collections;

public class Light : Main {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Helligkeit
	void Helligkeit () {
		float min=0.0;
		float max=100.0;
		int random;
		if (LSD == true) {min+=20.0;}
		if (bodyGood == true) {min +=5.0;}
		if (soulGood==true){min+=10.0;}
		if (thirdQuestion == 1) {max -=20.0;}
		//else if (thirdQuestion == 3) {max -=20.0;}
		random = Random.Range (min, max);
		if (0 > random < 20) {}
	}

	//Farbe
	void Farbe() {
		float min=0.0;
		float max=100.0;
		int random;
		if (LSD == true) {min+=20.0;}
		if (bodyGood == true) {min +=5.0;}
		if (soulGood==true){min+=10.0;}
		if (thirdQuestion == 1) {max -=20.0;}
		else if (thirdQuestion == 2) {min +=10.0;}
		else if (thirdQuestion == 3) {max -=20.0;}
		random = Random.Range (min, max);
		if (0 > random < 20) {}
	}
}
