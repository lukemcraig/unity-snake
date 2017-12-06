using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadMovementSystem : EgoSystem<
EgoConstraint<Transform, MovementComponent, InputQueueComponent>
>
{
	public override void Start ()
	{      
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler (Handle);
	}

	void Handle (TickEvent e)
	{
		constraint.ForEachGameObject (( egoComponent, transform, movement, iqc) => {
            if (!e.reverse && iqc.inputQueue.Count > 0)
            {
                Vector3 newDir = iqc.inputQueue.Dequeue();
                if (movement.nextMovement != -newDir)
                {
                    movement.nextMovement = newDir;
                }
            }
        });
	}
}
