using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	// GameObjects for the different doors
	public GameObject drugRoomDoor;
	public GameObject questionDoor1True;
	public GameObject questionDoor1False;
	public GameObject questionDoor2True;
	public GameObject questionDoor2False;
	private GameObject [] thirdQuestionDoors;

	// ObjectParameter Script for activating it
	public ObjectParameter objectParameter;
	public LightParameter lightParameter;

	// GameObjects for Drugs
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
	protected static int thirdQuestion; // 1: aufgedreht
					   			 		// 2: irgendwas seltsames
					   			 		// 3: Ruhe
	public static int getThirdQuestion() {
		return thirdQuestion;
	}

	// Array for transfering the important parameters to the other classes
	[HideInInspector]
	private static bool [] parameters = new bool[]{isLSD, isHeroine, isEcstasy, bodyGood, soulGood};
	[HideInInspector]
	public static bool [] Parameters {
		get { return parameters; }
		set { parameters = value; }
	}

	// Variables for stopping the Update of the main class after Setting Phase
	private bool simulationStarted;

	// Variables for managing the doors
	private int counter;
	private int questionDoorCounter;
	private bool secondDoors;
	private bool thirdDoors;


	// Use this for initialization
	void Start () {
		simulationStarted = true;
		thirdQuestionDoors = GameObject.FindGameObjectsWithTag ("thirdQuestionDoor");
	}

	// We use this for keeping our parameters when loading another scene
	void Awake() {
		DontDestroyOnLoad (this);
	}

	// Update is called once per frame
	void Update () {

		// Diese Bedingung beendet jegliche Raycasts nachdem die Parameter alle festgelegt wurden
		// und die Simulation beginnt, da Raycasts viel Leistung auffressen
		if (simulationStarted == true) {

			Vector3 fwd = transform.TransformDirection (Vector3.right);
			RaycastHit isHitDrug;
			
			if (Physics.Raycast (Player.transform.position, fwd, out isHitDrug, 2)) {

				print ("Ray wurde gecastet");

				// Vergleicht den Namen des mit dem Raycast getroffenen Objekts mit dem Namen
				// der Drogen und setzte die jeweiligen Bools auf true. (Falls "e" gedrückt ist)
				// TODO: den Text einblenden der bei der jeweiligen Droge angezeigt werden soll

				if (isHitDrug.collider.gameObject.name == LSD.name) {
					print ("Collider von LSD wurde getroffen");
					TextLSD.SetActive(true);
					if(Input.GetKey("e")){
						isLSD = true;
					}
				} else if (isHitDrug.collider.gameObject.name == Heroine.name) {
					print ("Collider von HEROIN wurde getroffen");
					TextHeroine.SetActive(true);
					if(Input.GetKey("e")){
						isHeroine = true;
					}
				} else if (isHitDrug.collider.gameObject.name == Ecstasy.name) {
					print ("Collider von ECSTASY wurde getroffen");
					TextEcstasty.SetActive(true);
					if(Input.GetKey("e")){
						isEcstasy = true;
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
				if (counter < 450) {
					drugRoomDoor.transform.Rotate(0, 0.2f, 0);
					drugRoomDoor.transform.position += new Vector3 (-0.002f, 0, 0.0021f);
					questionDoor1True.transform.Rotate(0, 0.2f, 0);
					questionDoor1True.transform.position += new Vector3 (-0.002f, 0, 0.0021f);
					questionDoor1False.transform.Rotate(0, 0.2f, 0);
					questionDoor1False.transform.position += new Vector3 (-0.002f, 0, 0.0021f);
					counter++;
				}	

				// OpenDoors method can be found on the bottom of this script - for opening the other doors
				openDoors();

				// Text nicht mehr anzeigen, weil Droge schon aktiviert
				TextLSD.SetActive(false);
				TextEcstasty.SetActive(false);
				TextHeroine.SetActive(false);

				RaycastHit isHit;

				if (Physics.Raycast (Player.transform.position, fwd, out isHit, 1)) {

					// Prüfung der ersten Frage -> Wie fühlst du dich heute?
					if (isHit.collider.gameObject.name == bodyGoodPositive.name) {
						print ("Player hat Parameter bodyGood (Positiv) ausgelöst");
						bodyGood = true;
						secondDoors = true;
					}
					if (isHit.collider.gameObject.name == bodyGoodNegative.name) {
						print ("Player hat Parameter bodyBad (Negativ) ausgelöst");
						bodyGood = false;
						secondDoors = true;
					}

					// Prüfung der zweiten Frage -> Wie ist deine Stimmung?
					if (isHit.collider.gameObject.name == soulGoodPositive.name) {
						print ("Player hat Parameter soulGood (Positiv) ausgelöst");
						soulGood = true;
						thirdDoors = true;
						questionDoorCounter = 0;
					}
					if (isHit.collider.gameObject.name == soulGoodNegative.name) {
						print ("Player hat Parameter soulGood (Negativ) ausgelöst");
						soulGood = false;
						thirdDoors = true;
						questionDoorCounter = 0;
					}

					// Prüfung der dritten Frage -> Welche Erwartung hast du?
					if (isHit.collider.gameObject.name == woundUp.name) {
						print ("Player hat die Erwartung 'Etwas Aufgedrehtes'");
						thirdQuestion = 1;
						simulationStarted = false;
						objectParameter.enabled = true;
						lightParameter.enabled = true;
					}
					if (isHit.collider.gameObject.name == Bizzare.name) {
						print ("Player hat die Erwartung 'Irgendwas Seltsames'");
						thirdQuestion = 2;
						simulationStarted = false;
						objectParameter.enabled = true;
						lightParameter.enabled = true;
					}
					if (isHit.collider.gameObject.name == Tranquility.name) {
						print ("Player hat die Erwartung 'Ruhe'");
						thirdQuestion = 3;
						simulationStarted = false;
						objectParameter.enabled = true;
						lightParameter.enabled = true;
					}
				}
			}
		}
	}

	void openDoors () {

		if (secondDoors == true) {
			if (questionDoorCounter < 450) {
				questionDoor2True.transform.Rotate(0, 0.2f, 0);
				questionDoor2True.transform.position += new Vector3 (-0.002f, 0, 0.0021f);
				questionDoor2False.transform.Rotate(0, 0.2f, 0);
				questionDoor2False.transform.position += new Vector3 (-0.002f, 0, 0.0021f);
				questionDoorCounter++;
			}
		}

		if (thirdDoors == true) {

			secondDoors = false;
			if (questionDoorCounter < 450) {
				foreach (GameObject thirdQuestionDoor in thirdQuestionDoors) {
					thirdQuestionDoor.transform.Rotate(0, 0.2f, 0);
					thirdQuestionDoor.transform.position += new Vector3 (-0.002f, 0, 0.0021f);
				}
				questionDoorCounter++;
			}
		}

	}

}