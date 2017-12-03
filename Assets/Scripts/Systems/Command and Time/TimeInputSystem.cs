using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeInputSystem : EgoSystem<
EgoConstraint<TimeInputComponent, InputQueueComponent>
>{
    
	public override void Update()
	{
		
		constraint.ForEachGameObject( ( egoComponent, input, inputQueueC) =>
			{
				
				if (Input.GetKeyDown (input.reverse)) {
					var reverseEvent = new ReverseTimeEvent(true);
					EgoEvents<ReverseTimeEvent>.AddEvent(reverseEvent);
				}		
				if (Input.GetKeyUp (input.reverse)) {
					var reverseEvent = new ReverseTimeEvent(false);
					EgoEvents<ReverseTimeEvent>.AddEvent(reverseEvent);
				}	
				
			} );		
	}
	
}