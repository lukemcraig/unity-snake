using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRecieveSystem: EgoSystem<
EgoConstraint<TickComponent, CommandManagerComponent>
> {
	public override void Start()
	{
		// Add Event Handlers
		EgoEvents<CommandEvent>.AddHandler( Handle );
	}
	
	void Handle( CommandEvent e )
	{
		constraint.ForEachGameObject((egoComponent, tick, commandManager) =>
			{
				//Debug.Log("added command " + e.command.ToString() +" at "+ (tick.currentTick+e.ticksTillExecution) + " on "+tick.currentTick);
				List<ICommand> commandList = new List<ICommand>();
				if(commandManager.commandDictionary.TryGetValue(tick.currentTick+e.ticksTillExecution, out commandList)){
					commandList.Add(e.command);					
				}
				else{
					commandList = new List<ICommand>();
					commandList.Add(e.command);
					commandManager.commandDictionary.Add(tick.currentTick+e.ticksTillExecution,commandList);
				}
				if(e.ticksTillExecution==0){
					e.command.ExecuteIfValid();
				}
			});
	}
}
