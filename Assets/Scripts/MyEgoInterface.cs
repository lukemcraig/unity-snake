using UnityEngine;
using System.Collections.Generic;

public class MyEgoInterface : EgoInterface
{
	static MyEgoInterface()
	{
//        Add Systems here:
        EgoSystems.Add(
			new TickSystem(),
			new InputSystem(),
			new MovementSystem(),
			new AIMoverSystem(),
			new SnakeHeadSystem(),
			new SnakePartSystem(),
			new EdibleCollisionSystem(),
			new ObstacleCollisionSystem()
        );	
		EgoEvents.AddFront<TickEvent>();
		EgoEvents.AddFront<CollisionEnterEvent>();
    }

    void Start()
    {
    	EgoSystems.Start();
	}
	
	void Update()
	{
		EgoSystems.Update();
	}
	
	void FixedUpdate()
	{
		EgoSystems.FixedUpdate();
	}
}
