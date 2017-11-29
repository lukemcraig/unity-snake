using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Strategies/Movement/Random")]
public class MSRandom : MovementStrategy {
    public override void Move(Transform transform,  CommandComponent command, MovementComponent movement){
        DoRandomStuff(transform, command, movement);
    }

    private void DoRandomStuff(Transform transform,  CommandComponent command, MovementComponent movement) {

        if (transform.position.y < 0) {
            if (movement.movementDirection != Vector3.down) {
                SetMovementDirection(Vector3.up, command.inputQueue);
                return;
            } else {
               if (TryToSetMovementDirection(Vector3.left, command.inputQueue, transform))
                return;
            }
        }
        else if (transform.position.y > 0){
            if (TryToSetMovementDirection(Vector3.down, command.inputQueue, transform))
            return;
        }


        switch (Random.Range(0, 4)) {
            case 0:
                if (TryToSetMovementDirection(Vector3.forward, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.left, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.back, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.right, command.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.up, command.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.down, command.inputQueue, transform)) {

                }
                break;
            case 1:
                if (TryToSetMovementDirection(Vector3.right, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.back, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.left, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.forward, command.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.up, command.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.down, command.inputQueue, transform)) {

                }
                break;
            case 2:
                if (TryToSetMovementDirection(Vector3.back, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.right, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.forward, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.left, command.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.up, command.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.down, command.inputQueue, transform)) {

                }
                break;
            case 3:
                if (TryToSetMovementDirection(Vector3.left, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.right, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.forward, command.inputQueue, transform)) {

                } else if (TryToSetMovementDirection(Vector3.back, command.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.up, command.inputQueue, transform)) {

                }
                else if (TryToSetMovementDirection(Vector3.down, command.inputQueue, transform)) {

                }
                break;
            default:
                break;
        }
    }

    bool TryToSetMovementDirection(Vector3 newDir, Queue<Vector3> inputQueue, Transform transform) {
        Vector3 fwd = transform.TransformDirection(newDir);
        Debug.DrawRay(transform.position, fwd, Color.green);
        if (Physics.Raycast(transform.position, fwd, 0.5f)) {
            return false;
        } else {
            SetMovementDirection(newDir, inputQueue);
            return true;
        }
    }

    void SetMovementDirection(Vector3 newDir, Queue<Vector3> inputQueue) {
        if (inputQueue != null) {
            inputQueue.Enqueue(newDir);
        }
    }

}
