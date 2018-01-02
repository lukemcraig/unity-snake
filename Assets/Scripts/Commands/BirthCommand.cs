using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthCommand : ICommand {
	
	//private SnakePartComponent grandparent;
	private SnakePartComponent parent;
	private SnakePartComponent child;
    private Vector3 position;
	private bool createdNew;
	
	public BirthCommand(SnakePartComponent parent, Vector3 position){
		this.parent = parent;
        this.position = position;
    }
	
	protected override void Execute(){
        parent.isPregnant = false;
		if (parent.childPart == null) {			
			child = Ego.AddGameObject( Object.Instantiate<GameObject>( parent.snakePrefab ) ).GetComponent<SnakePartComponent>();
			child.snakePrefab = parent.snakePrefab;
            child.transform.position = position;
            child.transform.rotation = parent.transform.rotation;
			child.transform.parent = parent.container;
			child.container = parent.container;
			parent.childPart = child;
			//child.parentPart = parent;
			createdNew = true;
		} else {
            createdNew = false;
            if (!parent.childPart.isPregnant)
            {
                parent.childPart.isPregnant = true;
                var commandEvent = new CommandEvent(new PregnancyCommand(parent.childPart, position, true), 1);
                EgoEvents<CommandEvent>.AddEvent(commandEvent);
            }
            
        }
	}
	
	protected override void Undo(){

        if (createdNew){
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
