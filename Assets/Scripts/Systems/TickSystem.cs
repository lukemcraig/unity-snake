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
					tick.partialTick += Time.deltaTime* tick.tickRate;
					if(tick.partialTick>=1f){
						tick.currentTick++;
						tick.partialTick -= (int) tick.partialTick;
						Debug.Assert(tick.partialTick < 1f );	
						
						var e = new TickEvent(tick.currentTick);
						EgoEvents<TickEvent>.AddEvent( e );
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
