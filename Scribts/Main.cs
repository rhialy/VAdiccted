using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

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
	protected bool isLSD;
	protected bool isHeroine;
	protected bool isEcstasy;

	// Booleans for our question-parameters (question 1 - 2)
	protected bool bodyGood;
	protected bool soulGood;

	// Integer for the third question with three possibilities
	protected int thirdQuestion; // 1: aufgedreht
					   			 // 2: irgendwas seltsames
					   			 // 3: Ruhe
	// Variables for stopping the Update of the main class after Setting Phase
	private bool simulationStarted;

	// Use this for initialization
	void Start () {
		simulationStarted = true;
	}

	// Update is called once per frame
	void Update () {

		// Diese Bedingung beendet jegliche Raycasts nachdem die Parameter alle festgelegt wurden
		// und die Simulation beginnt, da Raycasts viel Leistung auffressen
		if (simulationStarted == true) {

			Vector3 fwd = transform.TransformDirection (Vector3.right);
			RaycastHit isHitDrug;
			
			if (Physics.Raycast (Player.transform.position, fwd, out isHitDrug, 1)) {

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

				// Text nicht mehr anzeigen, weil Droge schon aktiviert
				TextLSD.SetActive(false);
				TextEcstasty.SetActive(false);
				TextHeroine.SetActive(false);

				RaycastHit isHit;

				if (Physics.Raycast (Player.transform.position, fwd, out isHit, 10)) {

					// Prüfung der ersten Frage -> Wie fühlst du dich heute?
					if (isHit.collider.gameObject.name == bodyGoodPositive.name) {
						print ("Player hat Parameter bodyGood (Positiv) ausgelöst");
						bodyGood = true;
					}
					if (isHit.collider.gameObject.name == bodyGoodNegative.name) {
						print ("Player hat Parameter bodyBad (Negativ) ausgelöst");
						bodyGood = false;
					}

					// Prüfung der zweiten Frage -> Wie ist deine Stimmung?
					if (isHit.collider.gameObject.name == soulGoodPositive.name) {
						print ("Player hat Parameter soulGood (Positiv) ausgelöst");
						soulGood = true;
					}
					if (isHit.collider.gameObject.name == soulGoodNegative.name) {
						print ("Player hat Parameter soulGood (Negativ) ausgelöst");
						soulGood = false;
					}

					// Prüfung der dritten Frage -> Welche Erwartung hast du?
					if (isHit.collider.gameObject.name == woundUp.name) {
						print ("Player hat die Erwartung 'Etwas Aufgedrehtes'");
						thirdQuestion = 1;
						simulationStarted = false;
					}
					if (isHit.collider.gameObject.name == Bizzare.name) {
						print ("Player hat die Erwartung 'Irgendwas Seltsames'");
						thirdQuestion = 2;
						simulationStarted = false;
					}
					if (isHit.collider.gameObject.name == Tranquility.name) {
						print ("Player hat die Erwartung 'Ruhe'");
						thirdQuestion = 3;
						simulationStarted = false;
					}
				}
			}
		}
	}
}
