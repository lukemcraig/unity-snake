using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TickComponent : MonoBehaviour {
	public int currentTick = 0;
	public float tickRate = 10;
	public bool reverse = false;
}
