using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePartSystem : EgoSystem<
EgoConstraint<Transform, SnakePartComponent>
>{
	public override void Start()
	{      
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler( Handle );
	}

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject( ( egoComponent, transform, snakePart ) =>
			{
				if (snakePart.childPart != null) {	
					var childEgoComponent = snakePart.childPart.gameObject.GetComponent<EgoComponent>();
					MovementComponent childMovement;
					if( childEgoComponent.TryGetComponents(out childMovement) )
					{
						childMovement.positionQueue.Enqueue (transform.position);
					}
				}
			} );
	}
}
