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
			new AgeSystem(),
            new SnakePregnancySystem(),
            new SnakeMaterialSystem(),
            new SnakePartSystem(),	
			new MovementSystem(),
			new EdibleCollisionSystem(),
			new ObstacleCollisionSystem(),
			new CommandRecieveSystem()
			
        );	
        
        EgoEvents.AddEnd<TickEvent>();
        EgoEvents.AddFront<CommandEvent>();
		EgoEvents.AddFront<TriggerEnterEvent>();
		
		
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
