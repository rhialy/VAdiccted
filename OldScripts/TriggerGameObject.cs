using UnityEngine;
using System.Collections;

public class TriggerGameObject : MonoBehaviour {

	// The object which will be changed
	// multiple objects can of course be added 
	public GameObject triggeredObject1;
	public GameObject triggeredObject2;
	public GameObject triggeredObject3;
	public GameObject groundUp;
	// So that only the specific trigger, triggers the specific effect
	public string triggerName;

	// These parameters are set only as examples for the real parameters
	// we will use in the finished version of the simulator
	// TODO:: How will these paramters change while the simulation proceeds?
	// They can't stay the same, so are these only the setters?
	public bool parameterSize;
	public bool parameterColor;
	public bool parameterPosition;
	// how much will the size change (per second the player stays on the trigger)
	public float sizeChange;
	// to what color will the triggeredObject change?
	public Material newMaterial;
	// vector: how much will the object move
	public Vector3 movement;

	// So the collider knows which GO is the Player
	private GameObject Player;
	private bool isActivating;
	private int endCounter;

	// Array for all Objects that are effected by the Effect Objects
	// Add Tag "TriggeredObject" to the GO if it should be included in this array.
	private GameObject[] triggeredObjects;

	// Use this for initialization
	void Start () {
		endCounter = 0;
		Player = GameObject.FindWithTag ("Player");
		triggeredObjects = GameObject.FindGameObjectsWithTag ("TriggeredObject");
	}
	
	// Update is called once per frame
	void Update(){
		if(isActivating == true){
			if(parameterSize == true){
				foreach (GameObject triggeredObject in triggeredObjects){
					sizeChange = Random.value;
					triggeredObject.transform.localScale += new Vector3 (0.0f, sizeChange, 0.0f);
				//triggeredObject1.transform.localScale += new Vector3 (0.0f, sizeChange, 0.0f);
				//triggeredObject2.transform.localScale += new Vector3 (0.0f, sizeChange, 0.0f);
				//triggeredObject3.transform.localScale += new Vector3 (0.0f, sizeChange, 0.0f);
				}
			}
			if(parameterColor == true){
				Material oldMaterial = triggeredObject1.GetComponent<Material>();
				oldMaterial = newMaterial;
			}
			if(parameterPosition == true){
				triggeredObject1.transform.position += movement;
				triggeredObject2.transform.position += movement;
				triggeredObject3.transform.position += movement;
			}
			endCounter++;
		}
		if (endCounter >= 220) {
			print ("grmblrbmlrbmrlbr");
			sizeChange = sizeChange * -1;
			movement = movement * -1;
		}
		if (endCounter >= 500) {
			//Vector3 noMovement = new Vector3(0.0f, 0.0f, 0.0f);
			//movement = noMovement;
			//sizeChange = 0.0f;
			parameterSize = false;
			parameterPosition = false;
			foreach(GameObject triggeredObject in triggeredObjects){
				triggeredObject.AddComponent<Rigidbody>();
			}
			Destroy(groundUp);
		}
	}

	// Method that determines if the Effect Trigger is actually activated.
	// Functions atm with a random counter. 
	// ToDo: replace random counter with real parameters -- OR: delete this whole method??
	void OnTriggerEnter(Collider Player){

		float randomCounter;
		randomCounter = Random.value;

		if (this.name == triggerName) {
			if (randomCounter > 0.5) {
				isActivating = true;
			}
			if (randomCounter < 0.5) {
				isActivating = false;
			}
		}
	}
}
