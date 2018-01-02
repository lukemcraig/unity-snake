using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : ICommand {
    private Transform transform;
    private Vector3 movementVector;
    private MovementComponent movementC;

    public MovementCommand(Transform transform, Vector3 movementVector, MovementComponent movementC)
    {
        this.transform = transform;
        this.movementVector = movementVector;
        this.movementC = movementC;
	}

	protected override void Execute(){
        transform.position += movementVector;
  //      movementC.currentMovement = movementVector;
		//movementC.nextMovement = movementVector;
	}

	protected override void Undo(){
        transform.position -= movementVector;
        movementC.nextMovement = movementVector;
        //movementC.currentMovement = -movementVector;
        //movementC.nextMovement = -movementVector;
    }

	protected override bool IsExecuteValid(){
		return ( movementC != null && transform != null);
	}
	protected override bool IsUndoValid(){
		return ( movementC != null && transform != null);
	}
}
