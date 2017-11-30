using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickEvent : EgoEvent {
	public readonly int tick;
	public TickEvent(int tick )
	{
		this.tick = tick;
	}
}
