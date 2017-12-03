using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayColliderSystem: EgoSystem<
EgoConstraint<DelayColliderComponent, BoxCollider>
>{
	public override void Start()
	{      
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler( Handle );
	}

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject( ( egoComponent, delayer, collider) =>
			{		
				if(delayer.ready){
				collider.enabled=true;
				Ego.DestroyComponent<DelayColliderComponent>(egoComponent);
				}
				else{
					delayer.ready = true;
				}
			} );
	}


}
