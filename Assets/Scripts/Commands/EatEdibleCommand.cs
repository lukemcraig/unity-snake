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
	
	protected override void Execute(){		
		edible.gameObject.SetActive(false);
		//TODO this should be handled by the edibles strategy instead
		SnakePartComponent snakePart;
		if (mouth.TryGetComponents (out snakePart)) {
            var pregEvent = new PregnancyEvent(snakePart);
            EgoEvents<PregnancyEvent>.AddEvent(pregEvent);
        }
	}
	
	protected override void Undo(){
		BoxCollider collider;
		if(edible.TryGetComponents( out collider )){
			collider.enabled = false;
			Ego.AddComponent<DelayColliderComponent>( edible );
		}
		edible.gameObject.SetActive(true);
		
	}
	protected override bool IsExecuteValid(){
		return ( edible != null && mouth!= null && edible.gameObject.activeInHierarchy);
	}
	protected override bool IsUndoValid(){
		return ( edible != null && !edible.gameObject.activeInHierarchy);
	}
}
