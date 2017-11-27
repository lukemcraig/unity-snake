using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementStrategy : ScriptableObject {
    public abstract void Move(Transform transform,  CommandComponent command, MovementComponent movement, SnakePartComponent snakePart);

}
