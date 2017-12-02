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
    }


    void Handle(PregnancyEvent e)
    {
        constraint.ForEachGameObject((egoComponent, snakePart) =>
        {
            if (e.newParent == snakePart )
            {
                var commandEvent = new CommandEvent(new PregnancyCommand(snakePart), 1);
                EgoEvents<CommandEvent>.AddEvent(commandEvent);
            }
        });
    }

}
