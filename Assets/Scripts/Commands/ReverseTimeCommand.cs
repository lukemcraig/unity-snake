using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseTimeCommand : ICommand {
	
	private bool reverse;
	
	public ReverseTimeCommand(bool reverse){
		this.reverse = reverse;
	}
	
	public override void Execute(){
		var reverseEvent = new ReverseTimeEvent(reverse);
		EgoEvents<ReverseTimeEvent>.AddEvent(reverseEvent);
	}
	
	public override void Undo(){
		
	}
}
