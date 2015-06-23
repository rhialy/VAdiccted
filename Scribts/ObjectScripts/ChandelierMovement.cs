using UnityEngine;
using System.Collections;

public class ChandelierMovement : MonoBehaviour {

	public HingeJoint[] chandeliers;

	private Vector3 force;
	private Vector3 backForce;
	private float counter;

	// Use this for initialization
	void Start () {
		counter = 0;
		force = new Vector3 (0, 10f, 0);
		backForce = new Vector3 (0, -10f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (counter <= 80) {
			foreach (HingeJoint chandelier in chandeliers) {
				JointMotor motor = chandelier.motor;
				motor.force = 45;
				motor.targetVelocity = 40;
				chandelier.motor = motor;
				chandelier.useMotor = true;
			}
			counter++;
			//print ("on");
		}
		if (counter >= 80) {
			foreach (HingeJoint chandelier in chandeliers) {
				JointMotor motor = chandelier.motor;
				motor.force = 45;
				motor.targetVelocity = -40;
				chandelier.motor = motor;
				chandelier.useMotor = true;
			}
			counter++;
			//print ("off");
		}
		if (counter >= 120) {
			counter = 0;
			//print ("restart");
		}
	}	
}
