using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class InputComponent : MonoBehaviour {
	public KeyCode forward = KeyCode.W;
	public KeyCode left = KeyCode.A;
	public KeyCode back = KeyCode.S;
	public KeyCode right = KeyCode.D;
	public KeyCode up = KeyCode.E;
	public KeyCode down = KeyCode.Q;
}
