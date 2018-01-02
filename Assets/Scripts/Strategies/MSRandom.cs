using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Strategies/Movement/Random")]
public class MSRandom : MovementStrategy {

    System.Random r = new System.Random();

    public override void Move(Transform transform,  InputQueueComponent iqc, MovementComponent movement){
        DoRandomStuff(transform, iqc, movement);
    }

    private void DoRandomStuff(Transform transform,  InputQueueComponent iqc, MovementComponent movement) {

        if (transform.position.y < 0) {
            if (movement.currentMovement != Vector3.down) {
                SetMovementDirection(Vector3.up, iqc.inputQueue);
                return;
            } else {
               if (TryToSetMovementDirection(Vector3.left, iqc.inputQueue, transform))
                return;
            }
        }
        else if (transform.position.y > 0){
            if (TryToSetMovementDirection(Vector3.down, iqc.inputQueue, transform))
            return;
        }

        List<Vector3> listOfDirections = new List<Vector3>() {Vector3.forward, Vector3.left, Vector3.right, Vector3.back};
        
        while (listOfDirections.Count > 0)
        {
            int randomIndex = r.Next(0, listOfDirections.Count);
            Vector3 direction = listOfDirections[randomIndex];
            listOfDirections.RemoveAt(randomIndex);
            if (TryToSetMovementDirection(direction, iqc.inputQueue, transform))
                return;
        }

    }

    bool TryToSetMovementDirection(Vector3 newDir, Queue<Vector3> inputQueue, Transform transform) {
        Vector3 fwd = transform.TransformDirection(newDir);
        Debug.DrawRay(transform.position, fwd, Color.green);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, fwd, out hit, 0.5f)) {
			var egoComponent = hit.collider.GetComponent<EgoComponent>();
			if (egoComponent != null) {
				if(egoComponent.HasComponents<ObstacleComponent>()){
					return false;
				}
			}
		}
        SetMovementDirection(newDir, inputQueue);
        return true;

    }

    void SetMovementDirection(Vector3 newDir, Queue<Vector3> inputQueue) {
        if (inputQueue != null) {
            inputQueue.Enqueue(newDir);
        }
    }

}
