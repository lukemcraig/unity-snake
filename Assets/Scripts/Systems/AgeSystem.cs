using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeSystem : EgoSystem<
EgoConstraint<AgeComponent>
> {
    public override void Start()
    {
        EgoEvents<TickEvent>.AddHandler( Handle );
    }

    void Handle( TickEvent e )
    {
        constraint.ForEachGameObject((egoComponent, age) =>
        {
           age.age++;
        });
    }

}

