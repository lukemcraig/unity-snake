using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementStrategy : ScriptableObject {
    public abstract void Move(Transform transform,  InputQueueComponent iqc, MovementComponent movement);

}
