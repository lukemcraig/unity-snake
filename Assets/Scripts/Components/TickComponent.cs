using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TickComponent : MonoBehaviour {
	public int currentTick = 0;
	public float tickRate = 10;
	public bool reverse = false;
	public float partialTick = 0f;
	public bool debugStep = false;
	public bool pause = true;
	
/* 	void OnGUI()
	{
		if(pause){
			if(GUI.Button(new Rect((Screen.width / 2) - 75, 5, 50, 30), "Step"))
			{
				debugStep = true;
			}
			if(GUI.Button(new Rect((Screen.width / 2) - 20, 5, 70, 30), !reverse ? "Forwards" : "Backwards"))
			{
				reverse = !reverse;
			}
		}
	} */
}
