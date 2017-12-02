using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandExecuteSystem: EgoSystem<
EgoConstraint<CommandManagerComponent>
> {
	public override void Start()
	{
		// Add Event Handlers
		EgoEvents<TickEvent>.AddHandler( Handle );
	}

	void Handle( TickEvent e )
	{
		constraint.ForEachGameObject((egoComponent, commandManager) =>
			{		
				List<ICommand> commandList;
				if(commandManager.commandDictionary.TryGetValue(e.tick, out commandList)){
					foreach(ICommand command in commandList){
						if(!e.reverse){
							command.Execute();
							Debug.Log("executed command"+ command.ToString());
						}
						else{
							command.Undo();
							Debug.Log("undid comamand");
						}
					}
				}
			});
	}
}
