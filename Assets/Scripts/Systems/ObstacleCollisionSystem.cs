using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionSystem : EgoSystem{
    public override void Start()
    {
        EgoEvents<TriggerEnterEvent>.AddHandler( Handle );
    }

	void Handle( TriggerEnterEvent e )
    {
        if( e.egoComponent1.HasComponents<ObstacleComponent>() && e.egoComponent2.HasComponents<VulnerableComponent>() )
        {
            // The first colliding GameObject is an edible
            DealWithCollision( e.egoComponent1,  e.egoComponent2 );
        }
		else if( e.egoComponent1.HasComponents<VulnerableComponent>() && e.egoComponent2.HasComponents<ObstacleComponent>() )
        {
            // The second colliding GameObject is a brick
			DealWithCollision( e.egoComponent2, e.egoComponent1 );
        }
    }

	void DealWithCollision( EgoComponent obstacle, EgoComponent vulnerable )
    {
		Ego.DestroyGameObject (vulnerable);

    }

}

