using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestRightSystem : EgoSystem<
EgoConstraint<InputQueueComponent>
>{
	
	
	public override void Start()
	{		
        // Add Event Handlers
        EgoEvents<TickEvent>.AddHandler(Handle);
    }    
	
	void SetMovementDirection (Vector3 newDir, InputQueueComponent iqc)
	{
		iqc.inputQueue.Enqueue (newDir);	
	}
	
	void Handle( TickEvent e )
	{
		
		constraint.ForEachGameObject( ( egoComponent, inputQueueC)=>
			{
				switch (e.tick%80){
				case 1:
					//Debug.Break();
					SetMovementDirection (Vector3.forward, inputQueueC);
					break;
				case 20:					
					SetMovementDirection (Vector3.left, inputQueueC);
					break;
				case 37:					
					SetMovementDirection (Vector3.back, inputQueueC);
					break;
				case 59:					
					SetMovementDirection (Vector3.right, inputQueueC);
					break;

				}
				
			} );
		
	}	
}
