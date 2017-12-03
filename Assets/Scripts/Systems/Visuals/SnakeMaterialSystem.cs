using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMaterialSystem : EgoSystem<
EgoConstraint<SnakePartComponent,AgeComponent, MeshRenderer>
>{
	
    public override void Update(){    	
        constraint.ForEachGameObject((egoComponent, snakePart, age, renderer) =>
        	{
        		if (snakePart.isPregnant)
        		{
        			renderer.material = snakePart.pregnantMaterial;        			
        		}
        		else{
        			if (age.age == 0)
        			{
        				renderer.material = snakePart.newMaterial;        				
        			}
        			else if (age.age > 0){
        				renderer.material = snakePart.normalMaterial;        				
        			}
        		}        		
        	});
    }
    
}
