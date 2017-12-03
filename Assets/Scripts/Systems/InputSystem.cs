using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class InputSystem : EgoSystem<
EgoConstraint<InputComponent, InputQueueComponent>
>{
	public override void Start()
	{
        // Add Event Handlers
        EgoEvents<TickEvent>.AddHandler(Handle);
    }
    
	public override void Update()
	{
		
		constraint.ForEachGameObject( ( egoComponent, input, inputQueueC) =>
			{
			
				if (Input.GetKeyDown (input.forward)) {
					SetMovementDirection (Vector3.forward, inputQueueC);
				}
				if (Input.GetKeyDown (input.left)) {
					SetMovementDirection (Vector3.left, inputQueueC);
				}
				if (Input.GetKeyDown (input.back)) {
					SetMovementDirection (Vector3.back, inputQueueC);
				}
				if (Input.GetKeyDown (input.right)) {
					SetMovementDirection (Vector3.right, inputQueueC);
				}
				if (Input.GetKeyDown (input.up)) {
					SetMovementDirection (Vector3.up, inputQueueC);
				}
				if (Input.GetKeyDown (input.down)) {
					SetMovementDirection (Vector3.down, inputQueueC);
				}
				
			} );
		
	}
	
	void SetMovementDirection (Vector3 newDir, InputQueueComponent iqc)
	{
		iqc.inputQueue.Enqueue (newDir);	
	}
	
	void Handle( TickEvent e )
	{
		if(e.reverse){
			constraint.ForEachGameObject( ( egoComponent, input, inputQueueC)=>
				{
					inputQueueC.inputQueue.Clear();
				} );
		}
	}	
}
