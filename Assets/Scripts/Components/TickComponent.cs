using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TickComponent : MonoBehaviour {
	public int currentTick = 0;
	public float tickRate = 10;
	public bool reverse = false;
	
	public bool debugStep = false;
	public bool pause = true;
	
		void OnGUI()
	{
		if(pause)
			if(GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Step Forward"))
			{
				debugStep = true;
			}
	}
}
