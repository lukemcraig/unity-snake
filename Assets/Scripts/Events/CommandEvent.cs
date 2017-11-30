using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandEvent : EgoEvent {
	public readonly ICommand command;
	public readonly int tickToExecuteOn;

	public CommandEvent(ICommand command, int tickToExecuteOn)
	{
		this.command = command;
		this.tickToExecuteOn = tickToExecuteOn;
	}
}
