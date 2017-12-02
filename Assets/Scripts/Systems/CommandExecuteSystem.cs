using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandExecuteSystem: EgoSystem<
EgoConstraint<TickComponent, CommandManagerComponent>
> {
	public override void Start()
	{
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler( Handle );
		//EgoEvents<CommandEvent>.AddHandler( Handle );
	}

/* 	void Handle( CommandEvent e )
	{
		constraint.ForEachGameObject((egoComponent, tick, commandManager) =>
			{
				Debug.Log("added command " + e.command.ToString());
				List<ICommand> commandList = new List<ICommand>();
				if(commandManager.commandDictionary.TryGetValue(e.tickToExecuteOn, out commandList)){
					commandList.Add(e.command);
					//Debug.Log("added command to existing list");
				}
				else{
					commandList = new List<ICommand>();
					commandList.Add(e.command);
					commandManager.commandDictionary.Add(e.tickToExecuteOn,commandList);
					//Debug.Log("added command to new list");
					//List<ICommand> commandListDebug = new List<ICommand>();
					//if(commandManager.commandDictionary.TryGetValue(e.tickToExecuteOn, out commandListDebug)){
					//	Debug.Log("and got it back");
					//	foreach(ICommand command in commandListDebug){
					//		Debug.Log("and it was " + command.ToString());
					//	}
					//}
					//else{
					//	Debug.Log("and didn't get it back");
					//}
				}
			});
	} */

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject((egoComponent, tick, commandManager) =>
			{
				Debug.Log("tick event " + tick.currentTick);
				List<ICommand> commandList;
				if(commandManager.commandDictionary.TryGetValue(tick.currentTick, out commandList)){

					foreach(ICommand command in commandList){
						if(!tick.reverse){
							command.Execute();
							Debug.Log("executed command"+ command.ToString());
						}
						else{
							command.Undo();
							Debug.Log("undid comamand");
						}
					}
				}
				//else{
				//	Debug.Log("no command lists for tick ");
				//}
			});
	}
}
