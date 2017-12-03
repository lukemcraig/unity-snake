using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoverSystem : EgoSystem<
EgoConstraint<Transform, AIMoverComponent, InputQueueComponent, MovementComponent>
> {
    public override void Start()
    {
        // Add Event Handlers
        EgoEvents<TickEvent>.AddHandler( Handle );
    }

    void Handle( TickEvent e )
    {
        constraint.ForEachGameObject((egoComponent, transform, aimover, inputQueue, movement) =>
        {
            aimover.movementStrategy.Move(transform, inputQueue, movement);
        });
    }

}

