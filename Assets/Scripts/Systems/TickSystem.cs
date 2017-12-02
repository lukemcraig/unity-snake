﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickSystem : EgoSystem<
EgoConstraint<TickComponent>
>{
	public override void Update()
	{
		constraint.ForEachGameObject( ( egoComponent, tick) =>
			{
				if(!tick.pause){
					tick.partialTick += Time.deltaTime* tick.tickRate;
					if(tick.partialTick>=1f){
						tick.currentTick++;
						tick.partialTick -= (int) tick.partialTick;
						Debug.Assert(tick.partialTick < 1f );	
						
						var e = new TickEvent(tick.currentTick, tick.reverse);
						EgoEvents<TickEvent>.AddEvent( e );
					}
				}       
				else{
					if(tick.debugStep==true){
						tick.debugStep=false;
						if(!tick.reverse)
							tick.currentTick++;
						else
							tick.currentTick--;						
						var e = new TickEvent(tick.currentTick, tick.reverse);
						EgoEvents<TickEvent>.AddEvent( e );	
					}
				}
			} );
	}	
}
