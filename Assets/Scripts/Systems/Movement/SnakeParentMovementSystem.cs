using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeParentMovementSystem : EgoSystem<
EgoConstraint<Transform, MovementComponent, SnakePartComponent>
>
{
	public override void Start ()
	{      
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler (Handle);
	}

	void Handle (TickEvent e)
	{
		constraint.ForEachGameObject (( egoComponent, transform, movement, snakePart) => {
			if (!egoComponent.gameObject.activeInHierarchy)
				return;

				transform.position += movement.currentMovement;

				if (snakePart.childPart != null) {	
					var childEgoComponent = snakePart.childPart.gameObject.GetComponent<EgoComponent> ();
					MovementComponent childMovement;					
					if (childEgoComponent.TryGetComponents (out childMovement)) {
						childMovement.nextMovement = movement.currentMovement;
					}
				}

				movement.currentMovement = movement.nextMovement;

		});
	}
}
