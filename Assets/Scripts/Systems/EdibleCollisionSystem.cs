using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleCollisionSystem : EgoSystem{
    public override void Start()
    {
        EgoEvents<TriggerEnterEvent>.AddHandler( Handle );
    }

	void Handle( TriggerEnterEvent e )
    {
        if( e.egoComponent1.HasComponents<EdibleComponent>() && e.egoComponent2.HasComponents<MouthComponent>() )
        {
            // The first colliding GameObject is an edible
            EatEdible( e.egoComponent1,  e.egoComponent2 );
        }
        else if( e.egoComponent1.HasComponents<MouthComponent>() && e.egoComponent2.HasComponents<EdibleComponent>() )
        {
            // The second colliding GameObject is a brick
            EatEdible( e.egoComponent2, e.egoComponent1 );
        }
    }

    void EatEdible( EgoComponent edible, EgoComponent mouth )
    {
		var commandEvent = new CommandEvent(new EatEdibleCommand(edible, mouth),0);
		EgoEvents<CommandEvent>.AddEvent(commandEvent);
    }

}

