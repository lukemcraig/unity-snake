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
				movement.movementDirection = movement.nextMovement;
				transform.position += movement.movementDirection;
			} );
	}
}
