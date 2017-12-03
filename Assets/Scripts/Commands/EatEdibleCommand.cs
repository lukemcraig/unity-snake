using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatEdibleCommand : ICommand {
	
	private EgoComponent edible;
	private EgoComponent mouth;
	
	public EatEdibleCommand(EgoComponent edible,EgoComponent mouth){
		this.edible = edible;
		this.mouth = mouth;
	}
	
	public override void Execute(){		
		//Ego.DestroyGameObject (edible);
		edible.gameObject.SetActive(false);

		SnakePartComponent snakePart;
		if (mouth.TryGetComponents (out snakePart)) {
            var pregEvent = new PregnancyEvent(snakePart);
            EgoEvents<PregnancyEvent>.AddEvent(pregEvent);
        }
	}
	
	public override void Undo(){
		BoxCollider collider;
		if(edible.TryGetComponents( out collider )){
			collider.enabled = false;
			Ego.AddComponent<DelayColliderComponent>( edible );
		}
		edible.gameObject.SetActive(true);
		
	}
}
