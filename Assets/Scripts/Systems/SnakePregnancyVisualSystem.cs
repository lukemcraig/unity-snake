using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePregnancyVisualSystem : EgoSystem<
EgoConstraint<SnakePartComponent, MeshRenderer>
>{
    int tick = 0;
    public override void Start()
	{
        // Add Event Handlers
        EgoEvents<TickEvent>.AddHandler(Handle);
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

    void Handle(TickEvent e)
    {
        tick = e.tick;
    }

    void Handle(PregnancyEvent e)
    {
        constraint.ForEachGameObject((egoComponent, snakePart, renderer) =>
        {
            if (e.newParent == snakePart)
            {
                var commandEvent = new CommandEvent(new ChangeMaterialCommand(renderer, snakePart.pregnantMaterial, tick + 2), tick + 2);
                EgoEvents<CommandEvent>.AddEvent(commandEvent);
                var commandEvent2 = new CommandEvent(new ChangeMaterialCommand(renderer, renderer.material, tick + 3), tick + 3);
                EgoEvents<CommandEvent>.AddEvent(commandEvent2);
            }
        });
    }

}
