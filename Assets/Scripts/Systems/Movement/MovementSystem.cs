using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : EgoSystem<
EgoConstraint<Transform, MovementComponent>
>
{
    public override void Start()
    {
        // Add Event Handlers
        EgoEvents<TickEvent>.AddHandler(Handle);
    }

    void Handle(TickEvent e)
    {
        constraint.ForEachGameObject((egoComponent, transform, movement) =>
        {
            movement.currentMovement = movement.nextMovement;
            if (!e.reverse)
            {
                var commandEvent = new CommandEvent(new MovementCommand(transform, movement.currentMovement, movement), 0);
                EgoEvents<CommandEvent>.AddEvent(commandEvent);
            }
        });
    }
}