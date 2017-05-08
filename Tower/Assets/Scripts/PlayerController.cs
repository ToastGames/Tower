using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public char jumpKey;
	public char leftKey;
	public char rightKey;

	public float moveDistance;
	public float jumpHeight;
	public float moveSpeed;
	public float jumpSpeed;

	private bool isJumping;
	private bool isMoving;
	private bool isFalling;

	private GameObject player;
	private Animator playerAnims;

	private Vector3 movementDelta;
	private Vector3 startPos;
	private Vector3 distanceTravelled;

	void Start()
	{
		player = gameObject.transform.FindChild ("Orientation-Correction").gameObject.transform.FindChild ("Mesh").gameObject;
		playerAnims = player.GetComponent<Animator> ();

		isJumping = false;
		isMoving = false;
		isFalling = false;
	}

	void Update ()
	{
		HandleInput ();
		UpdateMovement ();
	}

	private void HandleInput()
	{
		if (Input.inputString.Length == 1)
		{
			if (Input.inputString [0] == jumpKey)
				StartJump ();
			if (Input.inputString [0] == leftKey)
				StartMoveLeft ();
			if (Input.inputString [0] == rightKey)
				StartMoveRight ();
		}
	}

	private void UpdateMovement()
	{
		if (isMoving == true)
		{
			transform.position += movementDelta;
			distanceTravelled += movementDelta;
		}

		if (Mathf.Abs(distanceTravelled.x) >= moveDistance)
			StopMoving ();
	}

	private void StopMoving()
	{
		isMoving = false;
		distanceTravelled = new Vector3 (0, 0, 0);
	}

	private void StartJump ()
	{
	}

	private void StartMoveLeft ()
	{
		isMoving = true;
		movementDelta = new Vector3 (moveSpeed, 0, 0);
		startPos = transform.position;
	}

	private void StartMoveRight ()
	{
		isMoving = true;
		movementDelta = new Vector3 (-moveSpeed, 0, 0);
		startPos = transform.position;
	}
}
