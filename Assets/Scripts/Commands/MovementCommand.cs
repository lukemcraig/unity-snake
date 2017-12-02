using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : ICommand {
	private Transform transform;
	private MovementComponent movement;
	
	public MovementCommand(Transform transform, MovementComponent movement){
		this.movement = movement;
		this.transform = transform;
	}

	public override void Execute(){
		movement.movementDirection = movement.nextMovement;
		transform.position += movement.movementDirection;
	}

	public override void Undo(){
		Debug.Assert(transform != null);
		transform.position -= movement.movementDirection;
		movement.movementDirection = movement.nextMovement;
	}
}
