using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManagerSystem: EgoSystem<
EgoConstraint<TickComponent, CommandManagerComponent>
> {
	public override void Start()
	{
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler( Handle );
		EgoEvents<CommandEvent>.AddHandler( Handle );
	}

	void Handle( CommandEvent e )
	{
		constraint.ForEachGameObject((egoComponent, tick, commandManager) =>
			{
				List<ICommand> commandList = new List<ICommand>();
				if(commandManager.commandDictionary.TryGetValue(tick.currentTick, out commandList)){
					commandList.Add(e.command);
					Debug.Log("added command to existing list");
				}
				else{
					commandList = new List<ICommand>();
					commandList.Add(e.command);
					commandManager.commandDictionary.Add(tick.currentTick,commandList);
					Debug.Log("added command to new list");
				}
			});
	}

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject((egoComponent, tick, commandManager) =>
			{
				Debug.Log("tick event " + tick.currentTick);
				List<ICommand> commandList;
				if(commandManager.commandDictionary.TryGetValue(tick.currentTick, out commandList)){
					Debug.Log("found command list for tick");
					foreach(ICommand command in commandList){
						if(!tick.reverse){
							command.Execute();
							Debug.Log("executed command");
						}
						else{
							command.Undo();
							Debug.Log("undid comamand");
						}
					}
				}
				else{
					Debug.Log("no command lists for tick " + e.tick);
				}
			});
	}
}
