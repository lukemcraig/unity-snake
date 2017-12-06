using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePregnancySystem : EgoSystem<
EgoConstraint<Transform, SnakePartComponent>
>
{

    public override void Start()
    {
        // Add Event Handlers        
        EgoEvents<PregnancyEvent>.AddHandler(Handle);
    }


    void Handle(PregnancyEvent e)
    {
        constraint.ForEachGameObject((egoComponent, transform, snakePart) =>
            {
                if (e.newParent == snakePart)
                {
                    if (!snakePart.isPregnant)
                    {
                        var commandEvent = new CommandEvent(new PregnancyCommand(snakePart, transform.position), 1);
                        EgoEvents<CommandEvent>.AddEvent(commandEvent);
                    }
                }
            });
    }

}
