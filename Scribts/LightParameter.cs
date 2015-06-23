using UnityEngine;
using System.Collections;

public class LightParameter : MonoBehaviour {
	public Light Lt;
	private int counter;
	private int counter2;
	private int geschwindigkeit=240;
	private int delay;
	//Speichervariablen für zwei Farben ->fließender Übergang
	private Color c1;
	private Color c2;
	private Color c3;

	private int State=1;


	// Variables for using the Main parameters
	private bool LSD;
	private bool Heroine;
	private bool Ecstasy;
	private bool bodyGood;
	private bool soulGood;
	private int thirdQuestion;

	// Use this for initialization
	void Start () {

		// Initialize the Main parameters
     	LSD = Main.Parameters[0];
		Heroine = Main.Parameters[1];
		Ecstasy = Main.Parameters[2];
		bodyGood = Main.Parameters[3];
		soulGood = Main.Parameters[4];
		thirdQuestion = Main.getThirdQuestion();

		counter = 0;
		counter2 = 0;
		delay = 8;
		c1 = Color.white;
		c2 = Color.white;
		c3 = Color.white;

	}
	
	// Update is called once per frame
	void Update () {

		switch (State) {
		case 0:
			break;
		case 1:
			Helligkeit (geschwindigkeit, true, 0, 100);
			Farbe (geschwindigkeit, true, 0, 100);
			break;
		case 2:
			OnAndOf ();
			break;
		
		}
	
	}
	public void LightState( int i){
		State = i;
	}

	
	//Helligkeit
	public void Helligkeit (int geschwindigkeit, bool Pabhängig, float min, float max) {

		counter = counter + 1;

		if (counter == geschwindigkeit) {

			if(geschwindigkeit!=0){geschwindigkeit -=10;}

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
			if (20 < random && random < 40) {i1=0.3f; i2=0.4f;}
			if (40 < random && random < 60) {i1=2.0f; i2=2.8f;}
			if (60 < random && random < 80) {i1=4.5f; i2=5.0f;}
			if (80 < random && random < 100) {i1=7.0f; i2=7.0f;}

				//Lichtintensität festlegen
				float duration = 1.0f;
				float phi = Time.time / duration * 2 * Mathf.PI;
				float amplitude = Mathf.Cos (phi) * i1 + i2;
				Lt.intensity = amplitude;



		}
	}

	
	//Farbe
	public void Farbe( int geschwindigkeit, bool Panbhängigkeit, float min,float max) {
		//counter=counter +1;

		//speichervariable für Zufallszahl
		float random;

		//wird nur alle 5Sekunden ausgführt:
		if(counter==geschwindigkeit){
			//counter wird zurückgesetzt
			counter=0;


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
		c3 = Lt.color;
	}

	bool OnAndOf(){
		counter2 = counter2 + 1;
		
		if (counter2==delay) {
			counter2=0;
			if (Lt.color != Color.black) {
				Lt.color = Color.black;
				Lt.intensity = 0.0F;
				delay = Random.Range (8, 20);
				return true;
			}
			else if(counter2>17){counter2=0;}
			else {
				Lt.intensity = 8.0F;
				Lt.color = Color.white;
				return false;
			}
		}
		return false;

	}
	public void overcast(bool heller){
		if (heller == true) {
			Lt.range = 100.00F;
		} else {
			Lt.range = 27.00F;
		}
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



