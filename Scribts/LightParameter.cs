using UnityEngine;
using System.Collections;

public class LightParameter : Main {
	public Light Lt;
	private int counter;
	private int geschwindigkeit;
	//Speichervariablen für zwei Farben ->fließender Übergang
	private Color c1;
	private Color c2;
	// Use this for initialization
	void Start () {
		counter = 0;
		c1 = Color.white;
		c2 = Color.white;
		geschwindigkeit = 240;
	}
	
	// Update is called once per frame
	void Update () {
		Helligkeit (240,true,0,100);
		Farbe (240,true,0,100);
		Schwanken ();

	
	}
	
	//Helligkeit
	void Helligkeit (int geschwindigkeit, bool Pabhängig, float min, float max) {

		counter = counter + 1;

		if (counter == geschwindigkeit) {

				//speichervariablen für min und max Werte

				//speichervariable für Zufallszahl
				float random;
				//Speichervariablen für änderung der Intensitätsfaktoren
				float i1=3f;
				float i2=3f;
			if(Pabhängig==true){
				////Der durch die Anfangsparameter beeinflusste Wertebereich wird festgelegt
				if (LSD == true) {
					min += 20.0f;}
				if (bodyGood == true) {
					min += 5.0f;}
				if (soulGood == true) {
					min += 10.0f;}
				if (thirdQuestion == 1) {
					max -= 20.0f;} 
				else if (thirdQuestion == 3) {
					max -= 20.0f;}
			}
				//Zufallszahl aus dem Werteberreich wird festgelegt
				random = Random.Range (min, max);

				//mögliche Folgen
			if (0 < random && random < 20) {i1=0.01f; i2=0.01f;}
			if (20 < random && random < 40) {i1=0.1f; i2=0.4f;}
			if (40 < random && random < 60) {i1=1.0f; i2=2.0f;}
			if (60 < random && random < 80) {i1=4.0f; i2=4.0f;}
			if (80 < random && random < 100) {i1=7.0f; i2=7.0f;}

				//Lichtintensität festlegen
				float duration = 1.0f;
				float phi = Time.time / duration * 2 * Mathf.PI;
				float amplitude = Mathf.Cos (phi) * i1 + i2;
				Lt.intensity = amplitude;

			/*float du2=0.6F;
			float amp2 = Mathf.PingPong(Time.time, duration);
			amp2 = amp2 / du2 * 0.5F + 0.5F;
			Lt.range = Lt.range * amplitude;*/


		}
	}

	
	//Farbe
	void Farbe( int geschwindigkeit, bool Panbhängigkeit, float min,float max) {
		counter = counter + 1;

		//speichervariable für Zufallszahl
		float random;

		//wird nur alle 5Sekunden ausgführt:
		if(counter==geschwindigkeit){
			//counter wird zurückgesetzt
			counter=0;
			if(geschwindigkeit!=0){geschwindigkeit -=1;}

			if(Panbhängigkeit==true){
			////Der durch die Anfangsparameter beeinflusste Wertebereich wird festgelegt
			if (LSD == true) {min+=20.0f;}
			if (bodyGood == true) {min +=5.0f;}
			if (soulGood==true){min+=10.0f;}
			if (thirdQuestion == 1) {max -=20.0f;}
			else if (thirdQuestion == 2) {min +=10.0f;}
			else if (thirdQuestion == 3) {max -=20.0f;}
			}
			//Zufallszahl aus dem Werteberreich wird festgelegt
			random = Random.Range (min, max);
			//mögliche Folgefarben
			if (80 < random && random < 100) {c2 = Color.yellow;}
			if (60 < random && random < 80) {c2 = Color.green;}
			if (40 < random && random < 60) {c2 = Color.blue;}
			if (20 < random && random < 40) {c2 = Color.red;}
			if (0 < random && random < 20) {c2 = Color.grey;}
			//Übergang
			c1=Lt.color;

		}
		float duration=1.0f;
		float t = Mathf.PingPong(Time.time, duration) / duration;
		Lt.color=Color.Lerp (c1,c2,t);
	}

	void Schwanken(){

		Lt.spotAngle = Random.Range(10, 90);

	}

}
/*Licht schwanken lassen:lt.spotAngle = Random.Range(minAngle, maxAngle);
 * float amplitude = Mathf.PingPong(Time.time, duration);
        amplitude = amplitude / duration * 0.5F + 0.5F;
        lt.range = originalRange * amplitude;
 * Light.shadowStrength
 * ColorSpace.Gamma
 * Light.bounceIntensity eins ist normal
 * Light.cullingMask
 * 
 */



