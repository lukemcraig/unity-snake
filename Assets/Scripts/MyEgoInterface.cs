using UnityEngine;
using System.Collections.Generic;

public class MyEgoInterface : EgoInterface
{
	static MyEgoInterface()
	{
//        Add Systems here:
        EgoSystems.Add(
			new CommandExecuteSystem(),
			new DelayColliderSystem(),
			new TickSystem(),
			new InputSystem(),		
			new AIMoverSystem(),
			new SnakeHeadSystem(),
            new SnakePregnancySystem(),
            new SnakePregnancyVisualSystem(),
            new SnakePartSystem(),	
			new MovementSystem(),
			new EdibleCollisionSystem(),
			new ObstacleCollisionSystem(),
			new CommandRecieveSystem()
			
        );	
        EgoEvents.AddFront<CommandEvent>();		
		EgoEvents.AddFront<TriggerEnterEvent>();
		EgoEvents.AddEnd<TickEvent>();
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
