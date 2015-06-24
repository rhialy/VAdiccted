using UnityEngine;
using System.Collections;

public class ObjectParameter : MonoBehaviour {

	/*********HideParentVariablesInInspector*************/
	// Wir reinitialisieren jetzt alle Variablen der Eltern
	// Klasse um sie im Inspector zu verstecken
	// -> Bessere Übersichtlichkeit
	// TODO: HideInInspector Attribut funktioniert nicht um ein Feld
	// ein zweites mal zu serializen. Andere Methode?

	
	/*********************************************************************|
	| Dieses Script dient als "Handler" für alle kleineren Scripts die    |
	| mit der Änderung von Objekten zu tun haben. Dies dient nur der      |
	| Übersicht, da wenn alle Funktionen für alle sich verändernden       |
	| Objekte mit den jeweiligen public variables in diesem Script wären  |
	| würde die Übersichtlichkeit stark darunter leiden.				  |
	| Wichtig ist, dass alle diese Scripts Child Klassen dieser Klasse	  |
	| sein müssen, um die notwendigen Variablen zu erben.				  |
	|*********************************************************************/

	// Getter for every parameter
	private bool isLSD;
	private bool isHeroine;
	private bool isEcstasy;
	private bool bodyGood;
	private bool soulGood;
	private int thirdQuestion;

	// Hier werden die verschiedenen Scripts gelistet, die initialisiert werden sollen:


	// Die folgenden GOs sind notwendig, damit wir festlegen können bei welchem
	// Trigger welches Script für welche Objekte ausgelöst wird.


	// ArrayList for deactivating all trigger GOs at start
	private GameObject [] iniDeactivationGO;

	// Variables for inheriting to the child object scripts to
	// determine in which way everything is affected by our 4 parameters
	protected int movementIntensity;
	protected int sizeChangeIntensity;
	protected int completeIntensity;

	// Use this for initialization
	void Start () {
		// ini all GOs as not active
		iniDeactivationGO = GameObject.FindGameObjectsWithTag ("ObjectActivationTrigger");
		foreach (GameObject deactivation in iniDeactivationGO) {
			deactivation.SetActive (false);
		}
		// Initialisiere die Main Parameter
		isLSD = Main.Parameters[0];
		isHeroine = Main.Parameters[1];
		isEcstasy = Main.Parameters[2];
		bodyGood = Main.Parameters[3];
		soulGood = Main.Parameters[4];
		thirdQuestion = Main.getThirdQuestion();

		// System for defining the determining variables; affected by drugs
		if (isLSD == true) {
			print("LSD");
			movementIntensity 	= movementIntensity + 5;
			sizeChangeIntensity = sizeChangeIntensity + 5;
			completeIntensity 	= completeIntensity + 5;
		} else if (isHeroine == true) {
			print ("Heroine");
			movementIntensity 	= movementIntensity + 0;
			sizeChangeIntensity = sizeChangeIntensity + 0;
			completeIntensity 	= completeIntensity + 3;
		} else if (isEcstasy == true) {
			print ("Ecstasy");
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
			completeIntensity 	= completeIntensity + -5;
		} else if (Main.getThirdQuestion() == 3) {     // wound up
			movementIntensity 	= movementIntensity + 4;
			sizeChangeIntensity = sizeChangeIntensity + 0;
			completeIntensity 	= completeIntensity + 4;
		}
	}

	// Using this for keeping our variables
	void Awake() {
		DontDestroyOnLoad (this);
	}	

	// Update is called once per frame
	void Update () {
		//print (movementIntensity);
	}


}
