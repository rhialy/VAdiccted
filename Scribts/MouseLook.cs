using UnityEngine; 
using System.Collections;

 
//[AddComponentMenu("Camera-Control/Mouse Look")] 

public class MouseLook : MonoBehaviour {

	public GameObject player;
	public Rigidbody fpsPlayer;

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;


	float rotationY = 0F;

	// Update is called once per frame
	void Update ()
	{
		/********************************************************
		| The mouse look script is the other part of the 		|
		| player controller script. It uses another axis (or 	|
		| the mouse's input and transfers the y-axis to the 	|
		| camera-child object of the player and the x-axis to 	|
		| the player object itself. To change usage of 			|
		| controller or mouse, simply change the specific input.|
		********************************************************/
		if (axes == RotationAxes.MouseXAndY) {
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		} else if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		} else {
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(+rotationY, transform.localEulerAngles.y, 0);
		}
	}

	// Use this for initialization
	void Start ()
	{

		fpsPlayer = player.GetComponent<Rigidbody> ();
		// Make the rigid body not change rotation
		if (fpsPlayer) {
			fpsPlayer.freezeRotation = true;
		}
	}

}