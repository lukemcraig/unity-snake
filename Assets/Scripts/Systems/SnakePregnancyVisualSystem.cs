using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePregnancyVisualSystem : EgoSystem<
EgoConstraint<SnakePartComponent, MeshRenderer>
>{
	public override void Start()
	{      
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler( Handle );
	}		

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject( ( egoComponent, snakePart, renderer) =>
			{				
                if (snakePart.isPregnant) {
//					Debug.Log("p",egoComponent);
					renderer.material=snakePart.pregnantMaterial;
                }		
				else{
//					Debug.Log("e",egoComponent);
					renderer.material=snakePart.normalMaterial;
				}
			} );
	}

}
