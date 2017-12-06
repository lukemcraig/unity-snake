using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseTimeCommand : ICommand {
	//TODO why is this a command? does it need to be repeated? no.
	private bool reverse;
	
	public ReverseTimeCommand(bool reverse){
		this.reverse = reverse;
	}
	
	protected override void Execute(){
		var reverseEvent = new ReverseTimeEvent(reverse);
		EgoEvents<ReverseTimeEvent>.AddEvent(reverseEvent);
	}
}
