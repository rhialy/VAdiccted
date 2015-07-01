using UnityEngine;
using System.Collections;

public class LightParameter : MonoBehaviour {

	public Light Lt;

	private float counter;
	private float counter2;
	//Variable to decide how often the colour of the light changes
	private float geschwindigkeit=5;
	//delay of the flickering light
	private float delay = 0.13F;
	//Variables for two colours ->fluid transition
	private Color c1;
	private Color c2;

	//state of the light, used in the living room
	private int State=0;


	float  i=5.3F;

	// Variables for inheriting to the child object scripts to
	// determine in which way everything is affected by our 4 parameters
	protected static int movementIntensity = 0;
	protected static int sizeChangeIntensity = 0;
	protected static int completeIntensity = 0;

	// Variables for using the Main parameters
	protected bool LSD;
	protected bool Heroine;
	protected bool Ecstasy;
	protected bool bodyGood;
	protected bool soulGood;
	protected int thirdQuestion;

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
		c1 = Color.white;
		c2 = Color.white;

		// System for defining the determining variables; affected by drugs
		if (LSD == true) {
			//print("LSD");
			movementIntensity 	= movementIntensity + 5;
			sizeChangeIntensity = sizeChangeIntensity + 5;
			completeIntensity 	= completeIntensity + 5;
		} else if (Heroine == true) {
			//print ("Heroine");
			movementIntensity 	= movementIntensity + 0;
			sizeChangeIntensity = sizeChangeIntensity + 0;
			completeIntensity 	= completeIntensity + 3;
		} else if (Ecstasy == true) {
			//print ("Ecstasy");
			movementIntensity 	= movementIntensity + 0;
			sizeChangeIntensity = sizeChangeIntensity + 0;
			completeIntensity 	= completeIntensity + 5;
		}
		
		// System for defining the determining variables; affected by the 2 first parameters
		if (bodyGood == true) {
			movementIntensity 	= movementIntensity + 3;
			sizeChangeIntensity = sizeChangeIntensity + 3;
			completeIntensity 	= completeIntensity + 3;
		} else if (bodyGood == false) {
			movementIntensity 	= movementIntensity + 1;
			sizeChangeIntensity = sizeChangeIntensity + 1;
			completeIntensity 	= completeIntensity + 1;
		}
		
		if (soulGood == true) {
			movementIntensity 	= movementIntensity + 3;
			sizeChangeIntensity = sizeChangeIntensity + 3;
			completeIntensity 	= completeIntensity + 3;
		} else if (soulGood == false) {
			movementIntensity 	= movementIntensity + 1;
			sizeChangeIntensity = sizeChangeIntensity + 1;
			completeIntensity 	= completeIntensity + 1;
		}
		
		// System for defining the determining variables; affected by the third question
		if (Main.getThirdQuestion() == 1) {  // something bizzare
			movementIntensity 	= movementIntensity + 0;
			sizeChangeIntensity = sizeChangeIntensity + 4;
			completeIntensity 	= completeIntensity + 4;
		} else if (Main.getThirdQuestion() == 2) {    // something quiet
			movementIntensity 	= movementIntensity + 0;
			sizeChangeIntensity = sizeChangeIntensity + 0;
			completeIntensity 	= completeIntensity + -7;
		} else if (Main.getThirdQuestion() == 3) {     // wound up
			movementIntensity 	= movementIntensity + 4;
			sizeChangeIntensity = sizeChangeIntensity + 0;
			completeIntensity 	= completeIntensity + 4;
		}
	}
	
	// Update is called once per frame
	void Update () {

		switch (State) {
		case 0:
			break;
		case 1:
			Farbe (geschwindigkeit, true, 0, 100, Lt);
			Helligkeit (geschwindigkeit, true, 0, 100, Lt);

			break;
		case 2:
			OnAndOf (Lt);
			break;
		
		}
	

	}
	public void LightState( int i){
		State = i;
	}

	
	//brightness of the light
	public void Helligkeit (float geschwindigkeit, bool Pdependent, float min, float max, Light _Lt) {

		counter = counter + 1*Time.deltaTime;

		if (counter == geschwindigkeit) {


			//Variable for a random number
			float random;

			float i1 = 3f;
			float i2 = 3f;
			if (Pdependent == true) {

				//Sets the range of values
				if (LSD == true) {
					min += 25.0f;
				}
				if (bodyGood == true) {
					min += 5.0f;
				}
				if (soulGood == true) {
					min += 10.0f;
				}
				if (thirdQuestion == 1) {
					max -= 15.0f;
				} else if (thirdQuestion == 3) {
					max -= 15.0f;
				}
			}
			//random number is determined from the range of values
			random = Random.Range (min, max);
			//duration of the lightintensity
			float duration = 3.0f;

			//possible effect
			if (0 < random && random < 20) {i = 0.5F;}
			if (20 < random && random < 40) {i = 2.0F;}
			if (40 < random && random < 60) {i = 4.0F;}
			if (60 < random && random < 80) {i = 6.0F;}
			if (80 < random && random < 100) {i = 8.0F;}

		}

		_Lt.intensity=i;
		print (_Lt.intensity);
	}

	
	//Sets the Colour of the light
	public void Farbe(float geschwindigkeit, bool Panbhängigkeit, float min,float max, Light _Lt) {


		//Variable for the random number
		float random;
		//print (2);

		if(counter>=geschwindigkeit){
			//counter wird zurückgesetzt
			//print (1);
			counter=0;


			if(Panbhängigkeit==true){
				//Sets the range of values
			if (LSD == true) {min+=20.0f;}
			if (bodyGood == true) {min +=5.0f;}
			if (soulGood==true){min+=10.0f;}
			if (thirdQuestion == 1) {max -=20.0f;}
			else if (thirdQuestion == 2) {min +=10.0f;}
			else if (thirdQuestion == 3) {max -=20.0f;}
			}
			//Zufallszahl aus dem Werteberreich wird festgelegt
			random = Random.Range (min, max);
			//possible effect
			if (80 < random && random < 100) {c2 = new Color(1F, 0.92F, 0.016F, 1F);}
			if (55 < random && random < 80) {c2 = new Color(0F, 1F, 0F, 1F);}
			if (30 < random && random < 55) {c2 = new Color(0F, 0F, 1F, 1F);}
			if (8 < random && random < 30) {c2 = new Color(1F, 0F, 0F, 1F);}
			if (0 < random && random < 8) {c2 = new Color(0.5F, 0.5F, 0.5F, 1F);}
			//actual colour saved for a smooth flow from one to another colour
			c1=_Lt.color;
		
		}
		//flow between colour one and two
		float du=1.0f;
		float t = Mathf.PingPong(Time.time, du) / du;
		_Lt.color=Color.Lerp (c1,c2,t);

	}

	//flickering light
	public void OnAndOf(Light _Lt){
		if (bodyGood == false || soulGood == false || thirdQuestion == 1) {
			counter2 = counter2 + 1*Time.deltaTime;
			if (counter2 == delay) {
				counter2 = 0;
				if (_Lt.color != Color.black) {
					_Lt.color = Color.black;
					_Lt.intensity = 0.0F;
					delay = Random.Range (0.13F, 0.4F);

				} else if (counter2 > 17) {
					counter2 = 0;
				} else {
					_Lt.intensity = 8.0F;
					_Lt.color = Color.white;

				}
			}
		}
	}

	//a very bright light state
	public void overcast(bool heller){
		if (LSD == true || Ecstasy == true) {
			if (heller == true) {
				Lt.range = 100.00F;
			} else {
				Lt.range = 27.00F;
			}
		}
	}

}

/*if (0 < random && random < 20) {i1=0.1f; i2=0.2f;print (1);}
			if (20 < random && random < 40) {i1=0.5f; i2=1.0f;print (2);}
			if (40 < random && random < 60) {i1=1.6f; i2=2.0f;print (3);}
			if (60 < random && random < 80) {i1=4.0f; i2=5.0f;print (4);}
			if (80 < random && random < 100) {i1=7.0f; i2=7.0f;print (5);}

				//set lightintensity
				float amplitude=5.3F;
				float phi = Time.time / duration * 2 * Mathf.PI;
				amplitude = Mathf.Cos (phi) * i1 + i2;
				_Lt.intensity = amplitude;*/




