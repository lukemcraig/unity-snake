using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Strategies/Movement/Random")]
public class MSRandom : MovementStrategy {
    public override void Move(Transform transform,  InputQueueComponent iqc, MovementComponent movement){
        DoRandomStuff(transform, iqc, movement);
    }

    private void DoRandomStuff(Transform transform,  InputQueueComponent iqc, MovementComponent movement) {

        if (transform.position.y < 0) {
            if (movement.movementDirection != Vector3.down) {
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


        switch (Random.Range(0, 4)) {
            case 0:
                if (TryToSetMovementDirection(Vector3.forward, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.left, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.back, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.right, iqc.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.up, iqc.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.down, iqc.inputQueue, transform)) {

                }
                break;
            case 1:
                if (TryToSetMovementDirection(Vector3.right, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.back, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.left, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.forward, iqc.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.up, iqc.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.down, iqc.inputQueue, transform)) {

                }
                break;
            case 2:
                if (TryToSetMovementDirection(Vector3.back, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.right, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.forward, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.left, iqc.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.up, iqc.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.down, iqc.inputQueue, transform)) {

                }
                break;
            case 3:
                if (TryToSetMovementDirection(Vector3.left, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.right, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.forward, iqc.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.back, iqc.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.up, iqc.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.down, iqc.inputQueue, transform)) {

                }
                break;
            default:
                break;
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
