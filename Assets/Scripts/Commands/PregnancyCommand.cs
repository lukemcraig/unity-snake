using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancyCommand : ICommand {
	
	public SnakePartComponent parent;
	public PregnancyCommand(SnakePartComponent parent){
		this.parent = parent;
	}

	public override void Execute(){
		if (parent.childPart == null) {
			SnakePartComponent child = Ego.AddGameObject( Object.Instantiate<GameObject>( parent.snakePrefab ) ).GetComponent<SnakePartComponent>();
			child.transform.position = parent.transform.position;
			child.transform.rotation = parent.transform.rotation;
			child.transform.parent = parent.container;
			child.container = parent.container;
			parent.childPart = child;
			Debug.Log ("gave birth",parent);
		} else {
			parent.childPart.isPregnant=true;
			// TODO new event
			Debug.Log ("passed the torch",parent);
		}
	}

	public override void Undo(){

	}
}
