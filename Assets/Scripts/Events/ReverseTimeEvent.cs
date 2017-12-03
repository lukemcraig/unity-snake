using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseTimeEvent : EgoEvent {
	public bool reverse;
	public ReverseTimeEvent( bool reverse)
	{
       this.reverse = reverse;
    }
}
