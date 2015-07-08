using UnityEngine;
using System.Collections;

public class MyFirstRoomScribt : MonoBehaviour {
	// Variables for using the Main parameters
	private bool LSD;
	private bool Heroine;
	private bool Ecstasy;
	private bool bodyGood;
	private bool soulGood;
	private int thirdQuestion;

	//Objects of other Scripts(used to controll those Scripts)
	public LightParameter lightb;
	public Soundbehavior Soundi;
	public PlayerController Player;
	public FlyingFuniture Funiture;

	//Audioelements
	private AudioSource audi;
	public AudioClip scream;
	public AudioClip bird;
	
	private float count;

	// Use this for initialization
	void Start () {

		LSD = Main.Parameters[0];
		Heroine = Main.Parameters[1];
		Ecstasy = Main.Parameters[2];
		bodyGood = Main.Parameters[3];
		soulGood = Main.Parameters[4];
		thirdQuestion = Main.getThirdQuestion();

		audi = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

		;
		count += 1 * Time.deltaTime;




		//Timer to activate different functions.

		switch ((int)count) {
		case 1: 
			lightb.LightState(1);
		break;
		case 8:
			print ("case 8");
			lightb.crossfade (true);
		break;
		case 16:
			print ("case 16");
			lightb.crossfade (false);
		break;
		case 22:
			print ("case 22");
			Player.Heart ();
			Funiture.SizeSetActive(26,true);
		break;
		case 30:
			print ("case 30");
			if(bodyGood==true||soulGood==true){
				audi.clip=bird;
				audi.Play ();
			}
		break;
		case 32:
			print ("case 32");
			Funiture.JumpSetActive (15,true);
	 	break;
		case 35:
			print ("case 35");
			Funiture.SizeSetActive(0,false);
			Funiture.JumpSetActive (26,true);
			lightb.LightState (2);
		break;
		case 37:
			print ("case 37");
			lightb.crossfade (true);
		break;
		Player.Heart ();
		case 42:
			print ("case 42");
			if(thirdQuestion==3||LSD==true){ 
				audi.clip=scream;
				audi.Play ();
			}
		break;
		case 45:
			print ("case 45");
			Funiture.JumpSetActive (0,false);
			Funiture.FlySetActive (15,true);
			lightb.LightState (1);
		break;
		case 49:
			print ("case 49");
			Funiture.FlySetActive (26,true);
			lightb.crossfade (false);
		break;
		case 55: //end
			print ("case 55");
			print (count);
			Funiture.End();
		break;
		case 60:
			Application.LoadLevel(Application.loadedLevel + 1);
		break;
		}
	}

}
