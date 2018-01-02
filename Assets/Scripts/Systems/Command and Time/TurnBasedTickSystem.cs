using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedTickSystem : EgoSystem<
EgoConstraint<TickComponent>
>{
    
	public override void Start()
	{
		// Add Event Handlers
		EgoEvents<IncrementTickEvent>.AddHandler( Handle );
	}
	

	void Handle( IncrementTickEvent e )
	{
		constraint.ForEachGameObject( ( egoComponent, tick) =>
			{
				if(!tick.reverse)
					tick.currentTick++;
				else
					tick.currentTick--;		
				var te = new TickEvent(tick.currentTick, tick.reverse);
				EgoEvents<TickEvent>.AddEvent( te );	
			} );
		//Debug.Break();
	}
	
	
}