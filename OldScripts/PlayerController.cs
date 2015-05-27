using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public bool controllable = false;
	
	public float speed = 7.0f;
	public float runningSpeed = 12.0f;
	public float jumpSpeed = 6.0f;
	public static float gravity = 9.81f;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	
	// Use this for initialization
	void Start()
	{
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

			while (Input.GetKeyDown (KeyCode.LeftShift)) {
				moveDirection *= runningSpeed;
			}

			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;	
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

}