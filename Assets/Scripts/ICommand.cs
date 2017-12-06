using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICommand  {

	public void ExecuteIfValid(){
		if(IsExecuteValid ())
			Execute ();
	}
	public void UndoIfValid (){
		if(IsUndoValid ())
			Undo ();
	}
	protected abstract void Execute ();

	protected virtual void Undo (){

	}

	protected virtual bool IsExecuteValid (){
		return true;
	}
	protected virtual bool IsUndoValid (){
		return true;
	}

}
