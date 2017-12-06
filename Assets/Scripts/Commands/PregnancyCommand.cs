using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancyCommand : ICommand {
	
	//private SnakePartComponent grandparent;
	private SnakePartComponent parent;
	private SnakePartComponent child;
	private bool createdNew;
	
	public PregnancyCommand(SnakePartComponent parent){
		this.parent = parent;
	}
	
	protected override void Execute(){
		parent.isPregnant=false;
		if (parent.childPart == null) {			
			child = Ego.AddGameObject( Object.Instantiate<GameObject>( parent.snakePrefab ) ).GetComponent<SnakePartComponent>();
			child.snakePrefab = parent.snakePrefab;
			child.transform.position = parent.transform.position;
			child.transform.rotation = parent.transform.rotation;
			child.transform.parent = parent.container;
			child.container = parent.container;
			parent.childPart = child;
			child.parentPart = parent;
			createdNew = true;
		} else {
            var pregEvent = new PregnancyEvent(parent.childPart);
            EgoEvents<PregnancyEvent>.AddEvent(pregEvent);
            createdNew = false;
        }
	}
	
	protected override void Undo(){
		parent.isPregnant=true;
		if(createdNew){
			Ego.DestroyGameObject( child.GetComponent<EgoComponent>() );
			parent.childPart = null;
		}		
	}
	protected override bool IsExecuteValid(){
		return ( parent != null);
	}
	protected override bool IsUndoValid(){
		return ( parent != null && child != null);
	}
}
