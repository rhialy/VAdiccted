﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class PlayerController : MonoBehaviour {

	public static bool controllable = true;
	
	public float speed = 7.0f;
	public float runningSpeed = 12.0f;
	public float jumpSpeed = 6.0f;
	public float gravity = 20.0f;

	private Vector3 moveDirection = Vector3.zero;
	public Vector3 setMoveDirection (Vector3 newMoveDirection) {
		moveDirection = newMoveDirection;
		return moveDirection;
	}
	private CharacterController controller;

	private bool LSD;
	private bool Ecstasy;
	//Soundelemente
	public AudioSource HSource;
	public AudioSource FSource;
	public Soundbehavior Sound;

	private int c = 0;

	private float lastFrameHAxis;
	private bool hAxis;

	// Use this for initialization
	void Start() {
		controller = GetComponent<CharacterController>();
		LSD = Main.Parameters[0];
		Ecstasy = Main.Parameters[2];
	}
	
	// Update is called once per frame
	void Update()
	{

		if (controller.isGrounded && controllable)
		{	
			/********************************************************
			| Checking the horizontal and vertical Input			|
			| and applying it to the character controller			|
			| of the player gameobject. In this case				|
			| the right control stick of the 						|
			| controller. This script also applies a simple			|
			| simulation of gravity and the possibility to jump.	|
			| (both by simply supplying proper y-axis force)		|
			********************************************************/

			moveDirection = new Vector3(Input.GetAxis("Vertical")*-1, 0, Input.GetAxis("Horizontal"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			HSource = Sound.PlaySound (HSource);

			if (Input.GetAxisRaw("Vertical") != 0) {
				hAxis = true;
			} else {
				hAxis = false;
			}

			if (hAxis == true) {
				FSource = Sound.PlaySound (FSource);
			} else if (hAxis == false)  {
				Sound.StopSound (FSource);
			}

			/*while (Input.GetKeyDown (KeyCode.LeftShift)) {
				moveDirection *= runningSpeed;

			}*/

			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;	
			}

		}

		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;

	}
	// Always called after Update
	void LateUpdate() {
		lastFrameHAxis = Input.GetAxisRaw ("Horizontal");
	}

	public void Heart(){
		if (LSD == true || Ecstasy == true) {
			Sound.speed (HSource, 1.8F, true);
		}
	}

}