using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	// public variables for Script Manager GO, because "this" doesnt function properly in Unitys "Awake" method
	public GameObject ScriptManager;

	// Explanation to what the user should do next and which parameter he is triggering
	// For reference which position in the array is which sound file, look into the inspector of the GO
	public AudioSource[] manual;  

	// GameObjects for the different doors
	public GameObject drugRoomDoor;
	public GameObject ifThirdQuestionDoor;
	public GameObject questionDoor1True;
	public GameObject questionDoor1False;
	public GameObject questionDoor2True;
	public GameObject questionDoor2False;
	private GameObject [] thirdQuestionDoors;

	// ObjectParameter Script for activating it
	public ObjectParameter objectParameter;
	public LightParameter lightParameter;

	// GameObjects for Drugs
	/************************************************************
	| These fields are serialized to show that it would			|
	| be possible to use most "public" variables as "protected" |
	| ones. This is useful when trying to prevent someone 		|
	| hacking your software. The variables are protected, but   |
	| also show in the inspector. [Because of serialization].	|
	| But allas, not necessary for this simulation. And it 		|
	| leads to more problems than it solves.					|
	|***********************************************************/
	[SerializeField] protected GameObject LSD;
	[SerializeField] protected GameObject Heroine;
	[SerializeField] protected GameObject Ecstasy;

	// GameObjects for Question Parameters [question 1 && 2] [testing]
	[SerializeField] protected GameObject bodyGoodPositive;
	[SerializeField] protected GameObject bodyGoodNegative;
	[SerializeField] protected GameObject soulGoodPositive;
	[SerializeField] protected GameObject soulGoodNegative;

	// GameObjects for Question Parameters [question 3] [testing]
	public GameObject woundUp; // Etwas Aufgedrehtes
	public GameObject Bizzare; // Irgendwas seltsames
	public GameObject Tranquility; // ruhe

	// Player
	public GameObject Player;

	// GameObjects for displaying the text
	public GameObject TextLSD;
	public GameObject TextHeroine;
	public GameObject TextEcstasty;

	// Booleans for Drugs
	protected static bool isLSD;
	protected static bool isHeroine;
	protected static bool isEcstasy;

	// Booleans for our question-parameters (question 1 - 2)
	protected static bool bodyGood;
	protected static bool soulGood;

	// Integer for the third question with three possibilities
	protected static int thirdQuestion; // 1: irgendwas seltsames
					   			 		// 2: Ruhe
					   			 		// 3: etwas aufgedrehtes
	public static int getThirdQuestion() {
		return thirdQuestion;
	}

	// Array for transfering the important parameters to the other classes
	[HideInInspector]
	private static bool[] parameters;
	[HideInInspector]
	public static bool [] Parameters {
		get { return parameters; }
		set { parameters = value; }
	}

	// Variables for stopping the Update of the main class after setting all necessary parameters
	// as the main class is transfered to every scene and the raycasting uses lots of processing power
	private bool simulationStarted;

	// Variables for managing the doors
	private int soundPlayed;
	private float counter;
	private int phaseCounter;
	private float questionDoorCounter;
	private bool secondDoors;
	private bool thirdDoors;


	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		simulationStarted = true;
		thirdQuestion = 0;
		phaseCounter = 1;
		thirdQuestionDoors = GameObject.FindGameObjectsWithTag ("thirdQuestionDoor");
	}

	// We use this for keeping our parameters when loading another scene
	void Awake() {
		DontDestroyOnLoad (ScriptManager);
		//Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void Update () {

		// this conditional finishes the raycasting when all parameters are set
		// because raycasting is quite performance heavy.
		if (simulationStarted == true) {

			if(!manual[0].isPlaying && soundPlayed == 0){
				soundHandling (manual[0]);
				//manual[0].Play();
				soundPlayed = 1;
			}
			if(!manual[1].isPlaying && !manual[0].isPlaying && soundPlayed == 1){
				soundHandling (manual[1]);
				soundPlayed = 2;
			}

			Vector3 fwd = transform.TransformDirection (Vector3.right);
			RaycastHit isHitDrug;
			
			if (Physics.Raycast (Player.transform.position, fwd, out isHitDrug, 2)) {
			
				print ("Ray wurde gecastet");

				// compares the collider which is hit by the raycast and the name of the 
				// drug and sets the specific boolean true. (if "e" or "a-button" is pressed)
				if (phaseCounter == 1) {
					if (isHitDrug.collider.gameObject.name == LSD.name) {
						print ("Collider von LSD wurde getroffen");
						if(!manual[2].isPlaying && soundPlayed == 2){
							soundHandling (manual[2]);
							soundPlayed = 3;
						}
						if(!manual[3].isPlaying && !manual[2].isPlaying && soundPlayed == 3) {
							soundHandling (manual[3]);
							soundPlayed = 4;
						}

						TextLSD.SetActive(true);
						if(Input.GetButton("Fire2")){
							isLSD = true;
							soundPlayed = 4;
							phaseCounter = 2;
							Destroy (LSD);
						}
					} else if (isHitDrug.collider.gameObject.name == Heroine.name) {
						print ("Collider von HEROIN wurde getroffen");
						//TextHeroine.SetActive(true);
						if(Input.GetButton("Fire2")){
							isHeroine = true;
							phaseCounter = 2;
							Destroy (Heroine);
						}
					} else if (isHitDrug.collider.gameObject.name == Ecstasy.name) {
						print ("Collider von ECSTASY wurde getroffen");
						//TextEcstasty.SetActive(true);
						if(Input.GetButton("Fire2")){
							isEcstasy = true;
							phaseCounter = 2;
							Destroy(Ecstasy);
						}
					}
				}
			} else  {
				// Text nichtmehr anzeigen, wenn Player Raycast berührt Collider von Droge nicht mehr
				TextLSD.SetActive(false);
				TextEcstasty.SetActive(false);
				TextHeroine.SetActive(false);
			}
		

			// Zweites if-conditional, dass nur gecheckt wird wenn schon eine Droge ausgewählt wurde
			// damit nicht die ganze Zeit zwei Rays gecastet werden -> Leistungssteigerung
			if (isLSD == true || isHeroine == true || isEcstasy == true) {

				// Open the door to the three questions room:
				// UPDATE: and also the doors for the first question room, of course >.<
				if (drugRoomDoor.transform.position.z <= 0.85) {
					drugRoomDoor.transform.Rotate(0f, 1.0f, 0f);
					questionDoor1True.transform.Rotate(0f, 1.0f, 0f);
					questionDoor1False.transform.Rotate(0f, 1.0f, 0f);
					drugRoomDoor.transform.position += new Vector3 (-0.01f, 0, 0.0103f);
					questionDoor1True.transform.position += new Vector3 (-0.01f, 0, 0.0103f);
					questionDoor1False.transform.position += new Vector3 (-0.01f, 0, 0.0103f);
				}

				if(!manual[4].isPlaying && soundPlayed == 4){
					soundHandling (manual[4]);
					soundPlayed = 5;
				}
				if(!manual[5].isPlaying &&  !manual[4].isPlaying && soundPlayed == 5){
					soundHandling (manual[5]);
					soundPlayed = 6;
				}
				if(!manual[6].isPlaying && !manual[5].isPlaying && soundPlayed == 6) {
					soundHandling (manual[6]);
					soundPlayed = 7;
				}
				if(!manual[7].isPlaying && !manual[6].isPlaying && soundPlayed == 7) {
					soundHandling (manual[7]);
					soundPlayed = 8;
				}

				// OpenDoors method can be found on the bottom of this script - for opening the other doors
				openDoors();

				// Text nicht mehr anzeigen, weil Droge schon aktiviert
				TextLSD.SetActive(false);
				TextEcstasty.SetActive(false);
				TextHeroine.SetActive(false);

				RaycastHit isHit;

				if (Physics.Raycast (Player.transform.position, fwd, out isHit, 1)) {

					if (phaseCounter == 2) {
					// Prüfung der ersten Frage -> Wie fühlst du dich heute?
						if (isHit.collider.gameObject.name == bodyGoodPositive.name) {
							print ("Player hat Parameter bodyGood (Positiv) ausgelöst");
							bodyGood = true;
							secondDoors = true;
							phaseCounter = 3;
							soundPlayed = 8;
						}
						if (isHit.collider.gameObject.name == bodyGoodNegative.name) {
							print ("Player hat Parameter bodyBad (Negativ) ausgelöst");
							bodyGood = false;
							secondDoors = true;
							phaseCounter = 3;
							soundPlayed = 8;
						}
					}

					// Prüfung der zweiten Frage -> Wie ist deine Stimmung?
					if (phaseCounter == 3) {

						//print ("inside");

						if (isHit.collider.gameObject.name == soulGoodPositive.name) {
							print ("Player hat Parameter soulGood (Positiv) ausgelöst");
							soulGood = true;
							thirdDoors = true;
							questionDoorCounter = 0;
							phaseCounter = 4;
							soundPlayed = 11;
						}
						if (isHit.collider.gameObject.name == soulGoodNegative.name) {
							print ("Player hat Parameter soulGood (Negativ) ausgelöst");
							soulGood = false;
							thirdDoors = true;
							questionDoorCounter = 0;
							phaseCounter = 4;
							soundPlayed = 11;
						}
					}

					// Prüfung der dritten Frage -> Welche Erwartung hast du?
					if (phaseCounter == 4) {
						if (isHit.collider.gameObject.name == Bizzare.name) {
							print ("Player hat die Erwartung 'Irgendwas Seltsames'");
							thirdQuestion = 1;
							simulationStarted = false;
							phaseCounter = 5;
						}
						if (isHit.collider.gameObject.name == Tranquility.name) {
							print ("Player hat die Erwartung 'Ruhe'");
							thirdQuestion = 2;
							simulationStarted = false;
							phaseCounter = 5;
						}
						if (isHit.collider.gameObject.name == woundUp.name) {
							print ("Player hat die Erwartung 'Etwas Aufgedrehtes'");
							thirdQuestion = 3;
							simulationStarted = false;
							phaseCounter = 5;
						}
					}

				}
			}
		}

		if (phaseCounter == 5) {
			parameters = new bool[]{isLSD, isHeroine, isEcstasy, bodyGood, soulGood};
		}
	}

	void openDoors () {

		if (secondDoors == true) {

			if(!manual[8].isPlaying && soundPlayed == 8){
				soundHandling (manual[8]);
				soundPlayed = 9;
				print ("nummer 8");
			}
			if(!manual[9].isPlaying && !manual[8].isPlaying && soundPlayed == 9) {
				soundHandling (manual[9]);
				soundPlayed = 10;
				print ("nummer 9");
			}
			if(!manual[10].isPlaying && !manual[9].isPlaying && soundPlayed == 10) {
				soundHandling (manual[10]);
				soundPlayed = 11;
			}

			if (questionDoor2True.transform.position.z <= 5.0) {
				questionDoor2True.transform.Rotate(0, 1.0f, 0);
				questionDoor2True.transform.position += new Vector3 (-0.01f, 0, 0.0103f);
				questionDoor2False.transform.Rotate(0, 1.0f, 0);
				questionDoor2False.transform.position += new Vector3 (-0.01f, 0, 0.0103f);
				questionDoorCounter = questionDoorCounter + 1 * Time.deltaTime;
			}
		}

		if (thirdDoors == true) {

			if(!manual[11].isPlaying && soundPlayed == 11){
				soundHandling (manual[11]);
				soundPlayed = 12;
			}
			if(!manual[12].isPlaying && !manual[11].isPlaying && soundPlayed == 12) {
				soundHandling (manual[12]);
				soundPlayed = 13;
			}
			if(!manual[13].isPlaying && !manual[12].isPlaying && soundPlayed == 13) {
				soundHandling (manual[13]);
				soundPlayed = 14;
			}
			if(!manual[14].isPlaying && !manual[13].isPlaying && soundPlayed == 14) {
				soundHandling (manual[14]);
				soundPlayed = 15;
			}

			secondDoors = false;

			foreach (GameObject thirdQuestionDoor in thirdQuestionDoors) {
				if (ifThirdQuestionDoor.transform.position.z <= 5) {
					thirdQuestionDoor.transform.Rotate(0, 1.0f, 0);
					thirdQuestionDoor.transform.position += new Vector3 (-0.01f, 0, 0.0103f);
				}
				questionDoorCounter = questionDoorCounter + 1 * Time.deltaTime;
			}

		}

	}

	void soundHandling (AudioSource isPlaying) {
		foreach (AudioSource manualA in manual) {
			manualA.Stop ();
		}
		isPlaying.Play ();
	}

}