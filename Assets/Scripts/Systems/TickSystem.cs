using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickSystem : EgoSystem<
EgoConstraint<Transform, TickComponent>
>{
	public override void Update()
	{
		constraint.ForEachGameObject( ( egoComponent, transform, tick) =>
			{
				if(!tick.pause){
					int newTick = (int) (Time.time * tick.tickRate);
					
					if(tick.currentTick<newTick){
						var e = new TickEvent(tick.currentTick);
						EgoEvents<TickEvent>.AddEvent( e );
						tick.currentTick = newTick;
					}
				}
				else{
					if(tick.debugStep==true){
						tick.debugStep=false;
						tick.currentTick += 1;
						var e = new TickEvent(tick.currentTick);
						EgoEvents<TickEvent>.AddEvent( e );
						
					}
				}
			} );
	}
	
	
}
