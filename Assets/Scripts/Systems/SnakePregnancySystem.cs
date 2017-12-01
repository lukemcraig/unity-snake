using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePregnancySystem : EgoSystem<
EgoConstraint<SnakePartComponent>
>{
    int tick = 0;
	public override void Start()
	{
        // Add Event Handlers
        EgoEvents<TickEvent>.AddHandler( Handle );
        EgoEvents<PregnancyEvent>.AddHandler(Handle);
    }


    void Handle(TickEvent e)
    {
        tick = e.tick;
    }

    void Handle(PregnancyEvent e)
    {
        constraint.ForEachGameObject((egoComponent, snakePart) =>
        {
            if (e.newParent == snakePart )
            {
                var commandEvent = new CommandEvent(new PregnancyCommand(snakePart), tick + 2);
                EgoEvents<CommandEvent>.AddEvent(commandEvent);
            }
        });
    }

}
