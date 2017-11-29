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

	void CreateChild(SnakePartComponent snakePart, GameObject prefab){
		snakePart.isPregnant = false;
		if (snakePart.childPart == null) {
			SnakePartComponent child = Ego.AddGameObject( Object.Instantiate<GameObject>( prefab ) ).GetComponent<SnakePartComponent>();
			child.transform.position = snakePart.transform.position;
			child.transform.rotation = snakePart.transform.rotation;
			snakePart.childPart = child;
		} else {
//			CreateChild (snakePart.childPart, prefab);
			snakePart.childPart.isPregnant=true;
		}
	}

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject( ( egoComponent, snakePart) =>
			{
                if (snakePart.isPregnant) {
                    CreateChild(snakePart,snakePart.snakePrefab);
                }

			} );
	}

}
