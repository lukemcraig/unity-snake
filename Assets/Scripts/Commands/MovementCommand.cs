using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : ICommand {
	private Transform transform;
	private Vector3 movement;
	
	public MovementCommand(Transform transform, Vector3 movement){
		this.transform = transform;
		this.movement = movement;
	}

	public override void Execute(){		
		transform.position += movement;
	}

	public override void Undo(){
		Debug.Assert(transform != null);
		transform.position -= movement;
	}
}
