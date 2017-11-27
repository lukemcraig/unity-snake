using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSystem : EgoSystem<
EgoConstraint<CommandComponent>
>{
	public override void Update()
	{
		constraint.ForEachGameObject( ( egoComponent, commands) =>
			{
				
			} );
	}
}
