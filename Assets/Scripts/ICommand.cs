using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICommand  {

	public abstract void Execute();
	public abstract void Undo ();
}
