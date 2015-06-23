using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
	public bool controllable = false;
	
	public float speed = 7.0f;
	public float runningSpeed = 12.0f;
	public float jumpSpeed = 6.0f;
	public float gravity = 20.0f;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	private bool LSD;
	private bool Ecstasy;
	//Soundelemente
	public AudioSource HSource;
	public AudioSource FSource;
	public Soundbehavior Sound;
	private int c = 0;
	
	// Use this for initialization
	void Start()
	{
		LSD = Main.Parameters[0];
		Ecstasy = Main.Parameters[2];
		controller = GetComponent<CharacterController>();


	}
	
	// Update is called once per frame
	void Update()
	{

		if (controller.isGrounded && controllable)
		{	
			moveDirection = new Vector3(Input.GetAxis("Vertical")*-1, 0, Input.GetAxis("Horizontal"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;


			HSource=Sound.PlaySound (HSource);


			if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {

				FSource= Sound.PlaySound(FSource);

			} else {
				Sound.StopSound (FSource);
			}

			while (Input.GetKeyDown (KeyCode.LeftShift)) {
				moveDirection *= runningSpeed;

			}

			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;	
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

	}
	public void Heart(){
		if (LSD == true || Ecstasy == true) {
			Sound.speed (HSource, 1.8F, true);
		}
	}

}