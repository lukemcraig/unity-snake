using System.Collections.Generic;
using UnityEngine;

public class FutureErasalSystem : EgoSystem<
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
				if(e.reverse){
					int count = commandManager.commandDictionary.Count;
					for(int i = count; i > e.tick;i--){
						//Debug.Log("removing " + i);
						List<ICommand> commandList;
						if(commandManager.commandDictionary.TryGetValue(i, out commandList)){
							commandList.Clear();
						}
					}
				}				
			});
	}
	
}