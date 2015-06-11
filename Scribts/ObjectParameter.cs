using UnityEngine;
using System.Collections;

public class ObjectParameter : Main {

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

	// Hier werden die verschiedenen Scripts gelistet, die initialisiert werden sollen:
	public TestScript testScript;

	// Die folgenden GOs sind notwendig, damit wir festlegen können bei welchem
	// Trigger welches Script für welche Objekte ausgelöst wird.
	public GameObject testActivatedGameObject;

	// ArrayList for deactivating all trigger GOs at start
	private GameObject [] iniDeactivationGO;

	// Use this for initialization
	void Start () {
		// ini all GOs as not active
		iniDeactivationGO = GameObject.FindGameObjectsWithTag ("ObjectActivationTrigger");
		foreach (GameObject deactivation in iniDeactivationGO) {
			deactivation.SetActive (false);
		}
		//testScript = GetComponent<TestScript> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Wenn testTrigger is active, dann tue dies und das
		if (testActivatedGameObject.activeSelf) {
			testScript.enabled = true;
		}
	}


}
