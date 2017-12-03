using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : ICommand {
	private Transform transform;
	private Vector3 movementVector;
	private MovementComponent movementC;
	
	public MovementCommand(Transform transform, Vector3 movementVector, MovementComponent movementC ){
		this.transform = transform;
		this.movementVector = movementVector;
		this.movementC = movementC;
	}

	public override void Execute(){		
		transform.position += movementVector;
	}

	public override void Undo(){
		Debug.Assert(transform != null);
		transform.position -= movementVector;
		movementC.nextMovement = movementVector;
	}
}
