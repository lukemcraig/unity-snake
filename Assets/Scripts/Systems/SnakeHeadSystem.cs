using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadSystem : EgoSystem<
EgoConstraint<Transform, MovementComponent, CommandComponent, SnakePartComponent>
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
			CreateChild (snakePart.childPart, prefab);
		}
	}

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject( ( egoComponent, transform, movement, command, snakePart) =>
			{
                if (snakePart.isPregnant) {
                    CreateChild(snakePart,snakePart.snakePrefab);
                }
				if (command.inputQueue.Count > 0) {
					Vector3 newDir = command.inputQueue.Dequeue ();
					if (movement.movementDirection != -newDir) {
						movement.movementDirection = newDir;
					}
				}
				//transform.position = transform.position + movement.movementDirection;
                movement.positionQueue.Enqueue (transform.position + movement.movementDirection);
			} );
	}

}
