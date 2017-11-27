using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : MonoBehaviour
{
	[SerializeField]
	bool isPregnant = false;
	Queue<Vector3> inputQueue;

	[SerializeField] bool isHead = true;
	[SerializeField] bool isPlayer = false;

	public SnakePart childPart;
	public Vector3 movementDirection = Vector3.forward;
	public Queue<Vector3> positionQueue;

	public void Start ()
	{
		if (isHead) {
			inputQueue = new Queue<Vector3> ();
			EventManager.OnClicked += MoveHead;
		}
	}

	void MoveHead ()
	{
		if (inputQueue.Count > 0) {
			Vector3 newDir = inputQueue.Dequeue ();
			if (movementDirection != -newDir) {
				movementDirection = newDir;
			}
		}       
		if (childPart != null) {
			childPart.positionQueue.Enqueue (transform.position);
		}
		if (isPregnant) {
			CreateChild ();
		}
		transform.position = transform.position + movementDirection;
	}

	public void StartMoveRepeating ()
	{
		EventManager.OnClicked += MoveAStep;
	}

	void MoveAStep ()
	{
		if (positionQueue.Count > 0) {
			Vector3 nextPosition = positionQueue.Dequeue ();
			transform.position = nextPosition;

			if (childPart != null) {				
				childPart.positionQueue.Enqueue (transform.position);
			}
		}
	}

	void TakePlayerInput ()
	{
		if (Input.GetKey (KeyCode.Space)) {
			isPregnant = true;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			SetMovementDirection (Vector3.forward);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			SetMovementDirection (Vector3.left);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			SetMovementDirection (Vector3.back);
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			SetMovementDirection (Vector3.right);
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			SetMovementDirection (Vector3.up);
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			SetMovementDirection (Vector3.down);
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			EventManager.OnClicked += MoveAStep;
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			EventManager.OnClicked -= MoveAStep;
		}
	}

	void TakeAIInput ()
	{
		if (transform.position.y < 0) {
			if (movementDirection != Vector3.down) {
				SetMovementDirection (Vector3.up);
			} else {
				SetMovementDirection (Vector3.left);
			}
		}
		switch (Random.Range (0, 4)) {
		case 0:
			isPregnant = true;
			break;
		default:
			break;
		}

		switch (Random.Range (0, 4)) {
		case 0:
			if (TryToSetMovementDirection (Vector3.forward)) {

			} else if (TryToSetMovementDirection (Vector3.left)) {

			} else if (TryToSetMovementDirection (Vector3.back)) {

			} else if (TryToSetMovementDirection (Vector3.right)) {

			}
			break;
		case 1:
			if (TryToSetMovementDirection (Vector3.right)) {

			} else if (TryToSetMovementDirection (Vector3.back)) {

			} else if (TryToSetMovementDirection (Vector3.left)) {

			} else if (TryToSetMovementDirection (Vector3.forward)) {

			}
			break;
		case 2:
			if (TryToSetMovementDirection (Vector3.back)) {

			} else if (TryToSetMovementDirection (Vector3.right)) {

			} else if (TryToSetMovementDirection (Vector3.forward)) {

			} else if (TryToSetMovementDirection (Vector3.left)) {

			}
			break;
		case 3:
			if (TryToSetMovementDirection (Vector3.left)) {

			} else if (TryToSetMovementDirection (Vector3.right)) {

			} else if (TryToSetMovementDirection (Vector3.forward)) {

			} else if (TryToSetMovementDirection (Vector3.back)) {

			}
			break;
		default:
			break;
		}
	}

	public void Update ()
	{
		if (isHead) {
			if (isPlayer) {
				TakePlayerInput ();
			} else {
				TakeAIInput ();
			}
		}
	}

	bool TryToSetMovementDirection (Vector3 newDir)
	{
		Vector3 fwd = transform.TransformDirection (newDir);

		if (Physics.Raycast (transform.position, fwd, 0.5f)) {
			return false;
		} else {
			SetMovementDirection (newDir);
			return true;
		}
	}

	void SetMovementDirection (Vector3 newDir)
	{
		if (inputQueue != null) {
			inputQueue.Enqueue (newDir);
		}
	}

	public void CreateChild ()
	{
		isPregnant = false;
		if (childPart == null) {
			GameObject child = Instantiate (gameObject, transform.position, transform.rotation);
			childPart = child.GetComponent<SnakePart> ();
			childPart.isHead = false;
			childPart.positionQueue = new Queue<Vector3>();
			childPart.StartMoveRepeating ();
		} else {
			childPart.CreateChild ();
		}
	}
}
