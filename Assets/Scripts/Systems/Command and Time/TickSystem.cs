using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickSystem : EgoSystem<
EgoConstraint<TickComponent>
>{
	public override void Start()
	{
		// Add Event Handlers
		EgoEvents<ReverseTimeEvent>.AddHandler( Handle );
	}
	
	public override void Update()
	{
		constraint.ForEachGameObject( ( egoComponent, tick) =>
			{
	
				if(tick.reverse && tick.currentTick < 1)
					tick.reverse = false;
				
				if(!tick.pause){
					tick.partialTick += Time.deltaTime * tick.tickRate;
					
					if(tick.partialTick>=1f){						
						if(!tick.reverse)
							tick.currentTick++;
						else
							tick.currentTick--;

						tick.partialTick = 0;
						
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

	void Handle( ReverseTimeEvent e )
	{
		constraint.ForEachGameObject( ( egoComponent, tick) =>
			{
				Debug.Log("reverse" + e.reverse);
				tick.reverse = e.reverse;
			} );
	}

}
