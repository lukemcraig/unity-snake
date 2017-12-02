using UnityEngine;
using System.Collections;
[DisallowMultipleComponent]
public class EventManager : MonoBehaviour 
{
	public bool clicked = false;


	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Step Forward"))
		{
			clicked = true;
		}
	}


}