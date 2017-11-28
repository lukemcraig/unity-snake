using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoverSystem : EgoSystem<
EgoConstraint<Transform, AIMoverComponent, CommandComponent, MovementComponent, SnakePartComponent>
> {
    public override void Start()
    {
        // Add Event Handlers
        EgoEvents<TickEvent>.AddHandler( Handle );
    }

    void Handle( TickEvent e )
    {
        constraint.ForEachGameObject((egoComponent, transform, aimover, command, movement, snakePart) =>
        {
            aimover.movementStrategy.Move(transform, command, movement);
        });
    }

}

