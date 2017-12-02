using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickSystem : EgoSystem<
EgoConstraint<Transform, TickComponent, EventManager>
>{
	public override void Update()
	{
		constraint.ForEachGameObject( ( egoComponent, transform, tick, eventmanager) =>
			{
//				int newTick = (int) (Time.time * tick.tickRate);
//
//				if(tick.currentTick<newTick){
//					var e = new TickEvent(tick.currentTick);
//					EgoEvents<TickEvent>.AddEvent( e );
//					tick.currentTick = newTick;
//				}

				if(eventmanager.clicked==true){
					eventmanager.clicked=false;
					tick.currentTick += 1;
					var e = new TickEvent(tick.currentTick);
					EgoEvents<TickEvent>.AddEvent( e );

				}
			} );
	}


}
