using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : EgoSystem<
EgoConstraint<InputComponent, InputQueueComponent>
>{
	public override void Update()
	{
		constraint.ForEachGameObject( ( egoComponent, input, inputQueueC) =>
			{
				if (Input.GetKeyDown (input.forward)) {
					SetMovementDirection (Vector3.forward, inputQueueC);
				}
				if (Input.GetKeyDown (input.left)) {
					SetMovementDirection (Vector3.left, inputQueueC);
				}
				if (Input.GetKeyDown (input.back)) {
					SetMovementDirection (Vector3.back, inputQueueC);
				}
				if (Input.GetKeyDown (input.right)) {
					SetMovementDirection (Vector3.right, inputQueueC);
				}
				if (Input.GetKeyDown (input.up)) {
					SetMovementDirection (Vector3.up, inputQueueC);
				}
				if (Input.GetKeyDown (input.down)) {
					SetMovementDirection (Vector3.down, inputQueueC);
				}
			} );
	}

	void SetMovementDirection (Vector3 newDir, InputQueueComponent iqc)
	{
		iqc.inputQueue.Enqueue (newDir);	
	}
}
