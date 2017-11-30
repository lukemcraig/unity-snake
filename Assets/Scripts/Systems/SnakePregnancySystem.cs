using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePregnancySystem : EgoSystem<
EgoConstraint<SnakePartComponent>
>{
	public override void Start()
	{      
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler( Handle );
	}

//	void CreateChild(SnakePartComponent snakePart, GameObject prefab){
//		
//		if (snakePart.childPart == null) {
//			SnakePartComponent child = Ego.AddGameObject( Object.Instantiate<GameObject>( prefab ) ).GetComponent<SnakePartComponent>();
//			child.transform.position = snakePart.transform.position;
//			child.transform.rotation = snakePart.transform.rotation;
//			child.transform.parent = snakePart.container;
//			child.container = snakePart.container;
//			snakePart.childPart = child;
//			Debug.Log ("gave birth",snakePart);
//			snakePart.isPregnant = false;
//
//		} else {
//			snakePart.childPart.isPregnant=true;
//			Debug.Log ("passed the torch",snakePart);
//			snakePart.isPregnant = false;
//		}
//	}
		

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject( ( egoComponent, snakePart) =>
			{
                if (snakePart.isPregnant) {			
					snakePart.isPregnant = false;
					var commandEvent = new CommandEvent(new PregnancyCommand(snakePart, e.tick+2),e.tick+2);
					EgoEvents<CommandEvent>.AddEvent(commandEvent);
					Debug.Log("added delivery at " + (e.tick+2));
//                    CreateChild(snakePart,snakePart.snakePrefab);
                }			
			} );
	}

}
