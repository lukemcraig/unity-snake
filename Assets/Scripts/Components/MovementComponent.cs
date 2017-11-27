using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class MovementComponent : MonoBehaviour {
	
	public Queue<Vector3> positionQueue = new Queue<Vector3>();
	public Vector3 movementDirection = Vector3.forward;
}
