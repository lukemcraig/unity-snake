using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePregnancyVisualSystem : EgoSystem<
EgoConstraint<SnakePartComponent, MeshRenderer>
>{
    public override void Start()
	{
        // Add Event Handlers
       // EgoEvents<TickEvent>.AddHandler(Handle);
        EgoEvents<PregnancyEvent>.AddHandler(Handle);
    }

    //void Handle( TickEvent e )
    //{
    //	constraint.ForEachGameObject( ( egoComponent, snakePart, renderer) =>
    //		{				
    //               if (snakePart.isPregnant) {
    //                   var commandEvent = new CommandEvent(new ChangeMaterialCommand(renderer, snakePart.pregnantMaterial, e.tick + 2), e.tick + 2);
    //                   EgoEvents<CommandEvent>.AddEvent(commandEvent);                  
    //               }		
    //		} );
    //}

    void Handle(PregnancyEvent e)
    {
        constraint.ForEachGameObject((egoComponent, snakePart, renderer) =>
        {
            if (snakePart == e.newParent)
            {
                var commandEvent = new CommandEvent(new ChangeMaterialCommand(renderer, snakePart.pregnantMaterial), 0);
                EgoEvents<CommandEvent>.AddEvent(commandEvent);
                var commandEvent2 = new CommandEvent(new ChangeMaterialCommand(renderer, renderer.material), 1);
                EgoEvents<CommandEvent>.AddEvent(commandEvent2);
            }
        });
    }

}
