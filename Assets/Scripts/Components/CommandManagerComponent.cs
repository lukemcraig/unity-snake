using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManagerComponent : MonoBehaviour {

	public Dictionary<int,List<ICommand>> commandDictionary = new Dictionary<int,List<ICommand>> ();

}
