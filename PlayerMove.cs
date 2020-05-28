using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
	public float movementSpeed = 10f;
	public float jumpSpeed = 10f, gravity = -5;
	private CharacterController charController;
	float vSpeed = 0;
	public float health = 100f;
	public float maxHealth = 100f;
	public AudioSource audioCorazon;
	public AudioSource audioEstrella;
	public AudioSource audioOff;
	public int lifes = 3;

	private void Awake()
	{
		charController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		float horizInput = Input.GetAxis("Horizontal") * movementSpeed;
		float vertInput = Input.GetAxis("Vertical") * movementSpeed;
		if(health > 100f)
		{
			health = 100f;
		}
		Vector3 forwardMovement = transform.forward * vertInput;
		Vector3 rightMovement = transform.right * horizInput;

		Vector3 moveDir = forwardMovement + rightMovement;
		moveDir += Physics.gravity;

		if(charController.isGrounded){
			vSpeed = 0;
			if(Input.GetButtonDown("Jump")){
				vSpeed = jumpSpeed;
			}
		}
		vSpeed += gravity;
		moveDir.y = vSpeed;

		charController.Move(moveDir * Time.deltaTime);

	}



}