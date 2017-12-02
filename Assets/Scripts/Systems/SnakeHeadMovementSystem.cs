using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadMovementSystem : EgoSystem<
EgoConstraint<MovementComponent, CommandComponent>
>{
	public override void Start()
	{      
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler( Handle );
	}

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject( ( egoComponent, movement, command) =>
			{
				if (command.inputQueue.Count > 0) {
					Vector3 newDir = command.inputQueue.Dequeue ();
					if (movement.nextMovement != -newDir) {
						movement.nextMovement = newDir;
					}
				}
			} );
	}

}
