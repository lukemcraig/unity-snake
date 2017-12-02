using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancyCommand : ICommand {
	
	public SnakePartComponent parent;
	
	public PregnancyCommand(SnakePartComponent parent){
		this.parent = parent;
	}

	public override void Execute(){
		parent.isPregnant=false;
		if (parent.childPart == null) {
			
			SnakePartComponent child = Ego.AddGameObject( Object.Instantiate<GameObject>( parent.snakePrefab ) ).GetComponent<SnakePartComponent>();
			child.snakePrefab = parent.snakePrefab;
			child.transform.position = parent.transform.position;
			child.transform.rotation = parent.transform.rotation;
			child.transform.parent = parent.container;
			child.container = parent.container;
			parent.childPart = child;
		} else {
            var pregEvent = new PregnancyEvent(parent.childPart);
            EgoEvents<PregnancyEvent>.AddEvent(pregEvent);
        }
	}

	public override void Undo(){

	}
}
