using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class InputQueueComponent : MonoBehaviour {
	public Vector3 lastInput;
	public Queue<Vector3> inputQueue = new Queue<Vector3> ();
}