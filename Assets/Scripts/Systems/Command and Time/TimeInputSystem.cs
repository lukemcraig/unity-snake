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
					var commandEvent = new CommandEvent(new ReverseTimeCommand(true),0);
					EgoEvents<CommandEvent>.AddEvent(commandEvent);
				}		
				if (Input.GetKeyUp (input.reverse)) {
					var commandEvent = new CommandEvent(new ReverseTimeCommand(false),0);
					EgoEvents<CommandEvent>.AddEvent(commandEvent);
				}	
				
			} );		
	}
	
}