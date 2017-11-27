using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : EgoSystem<
EgoConstraint<Transform, MovementComponent>
>{
	public override void Start()
	{      
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler( Handle );
	}

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject( ( egoComponent, transform, movement) =>
			{				
				if (movement.positionQueue.Count > 0) {
					Vector3 nextPosition = movement.positionQueue.Dequeue ();
					transform.position = nextPosition;
				}
			} );
	}
}
