using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamSystem : EgoSystem<
EgoConstraint<RoomSwitchComponent>
>
{
	public override void Start ()
	{
		EgoEvents<TriggerEnterEvent>.AddHandler (Handle);
	}

	void Handle (TriggerEnterEvent e)
	{
		if (e.egoComponent1.HasComponents<RoomSwitchComponent>() && e.egoComponent2.HasComponents<RoomSwitchAgentComponent>() ) {
			// The first colliding GameObject is an edible
			DealWithCollision (e.egoComponent1, e.egoComponent2);
		}
		else if (e.egoComponent1.HasComponents<RoomSwitchAgentComponent>() && e.egoComponent2.HasComponents<RoomSwitchComponent>()) {
			// The first colliding GameObject is an edible
			DealWithCollision (e.egoComponent1, e.egoComponent2);
		}
	}

	void DealWithCollision (EgoComponent roomswitch, EgoComponent agent)
	{
		RoomSwitchComponent rsc;
		RoomSwitchAgentComponent rsca;
		if (roomswitch.TryGetComponents<RoomSwitchComponent> (out rsc) && agent.TryGetComponents<RoomSwitchAgentComponent> (out rsca) ) {
			if (rsca.autoCam.Target == rsc.room1) {
				rsca.autoCam.SetTarget (rsc.room2);
			} else {
				rsca.autoCam.SetTarget (rsc.room1);
			}

		}
	}
    
}

