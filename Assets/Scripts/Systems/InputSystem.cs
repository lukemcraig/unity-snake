using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : EgoSystem<
EgoConstraint<Transform, InputComponent, CommandComponent>
>{
	public override void Update()
	{
		constraint.ForEachGameObject( ( egoComponent, transform, input, command) =>
			{
				if (Input.GetKeyDown (input.forward)) {
					SetMovementDirection (Vector3.forward, command.inputQueue);
				}
				if (Input.GetKeyDown (input.left)) {
					SetMovementDirection (Vector3.left, command.inputQueue);
				}
				if (Input.GetKeyDown (input.back)) {
					SetMovementDirection (Vector3.back, command.inputQueue);
				}
				if (Input.GetKeyDown (input.right)) {
					SetMovementDirection (Vector3.right, command.inputQueue);
				}
				if (Input.GetKeyDown (input.up)) {
					SetMovementDirection (Vector3.up, command.inputQueue);
				}
				if (Input.GetKeyDown (input.down)) {
					SetMovementDirection (Vector3.down, command.inputQueue);
				}
			} );
	}

	void SetMovementDirection (Vector3 newDir, Queue<Vector3> inputQueue)
	{
		if (inputQueue != null) {
			inputQueue.Enqueue (newDir);
		}
	}
}
