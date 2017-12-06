using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : ICommand {

	private Vector3 movementVector;
	private MovementComponent movementC;
	
	public MovementCommand(Vector3 movementVector, MovementComponent movementC ){
		this.movementVector = movementVector;
		this.movementC = movementC;
	}

	protected override void Execute(){		
		movementC.currentMovement = movementVector;
		movementC.nextMovement = movementVector;
	}

	protected override void Undo(){
		movementC.currentMovement = -movementVector;
		movementC.nextMovement = -movementVector;
	}

	protected override bool IsExecuteValid(){
		return ( movementC != null);
	}
	protected override bool IsUndoValid(){
		return ( movementC != null);
	}
}
