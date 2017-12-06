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
			if (!e.reverse) {
				Vector3 newDir = movement.currentMovement;
				if (iqc.inputQueue.Count > 0) {
					newDir = iqc.inputQueue.Dequeue ();
				}
				var commandEvent = new CommandEvent (new MovementCommand (newDir, movement), 0);
				EgoEvents<CommandEvent>.AddEvent (commandEvent);
			}
		});
	}
}
