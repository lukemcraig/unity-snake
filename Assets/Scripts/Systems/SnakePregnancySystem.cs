using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePregnancySystem : EgoSystem<
EgoConstraint<SnakePartComponent>
>{
	
	public override void Start()
	{
        // Add Event Handlers
        
        EgoEvents<PregnancyEvent>.AddHandler(Handle);
        EgoEvents<TickEvent>.AddHandler(Handle);
    }
    
    void Handle(TickEvent e)
    {
        constraint.ForEachGameObject((egoComponent, snakePart) =>
        	{
        		if (snakePart.isPregnant == true)
        		{
        			if(!e.reverse){
        				//snakePart.isPregnant = false;
        				var commandEvent = new CommandEvent(new PregnancyCommand(snakePart), 0);
        				EgoEvents<CommandEvent>.AddEvent(commandEvent);
        			}
        			else {
        				snakePart.isPregnant = false;
        			}
        		}
        		
        	});
    }
    
    void Handle(PregnancyEvent e)
    {
        constraint.ForEachGameObject((egoComponent, snakePart) =>
        	{
        		if (e.newParent == snakePart )
        		{
        			snakePart.isPregnant = true;
        			
        		}
        	});
    }
    
}
