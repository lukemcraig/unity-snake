using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandEvent : EgoEvent {
	public readonly ICommand command;
	public readonly int ticksTillExecution;

	public CommandEvent(ICommand command, int ticksTillExecution)
	{
		this.command = command;
		this.ticksTillExecution = ticksTillExecution;
	}
}
