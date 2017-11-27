using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CommandComponent : MonoBehaviour {

	public Queue<Vector3> inputQueue = new Queue<Vector3> ();
}