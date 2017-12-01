using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancyEvent : EgoEvent {
	public readonly SnakePartComponent newParent;
	public PregnancyEvent(SnakePartComponent newParent)
	{
        this.newParent = newParent;
    }
}
