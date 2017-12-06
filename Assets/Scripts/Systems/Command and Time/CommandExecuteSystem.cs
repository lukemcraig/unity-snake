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
				if(!e.reverse){
					if(commandManager.commandDictionary.TryGetValue(e.tick, out commandList)){
						foreach(ICommand command in commandList){							
							command.ExecuteIfValid();
							//Debug.Log("executed command"+ command.ToString());;							
						}
					}					
				}
				else{
					if(commandManager.commandDictionary.TryGetValue(e.tick+1, out commandList)){
						foreach(ICommand command in commandList){		
							command.UndoIfValid();							
							//Debug.Log("undid comamand");							
						}
					}					
					commandList.Clear();					
				}
			});
	}
}
