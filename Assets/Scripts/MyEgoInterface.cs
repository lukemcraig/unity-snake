using UnityEngine;
using System.Collections.Generic;

public class MyEgoInterface : EgoInterface
{
	static MyEgoInterface()
	{
		//        Add Systems here:
        EgoSystems.Add(
        	new TickSystem(),
        	
			new CommandExecuteSystem(),			
			new DelayColliderSystem(),
			//new AIMoverSystem(),
			new InputSystem(),					
			new SnakeHeadMovementSystem(),
			new MovementSystem(),
			//new SnakeParentMovementSystem(),
			new AgeSystem(),			
            //new SnakePregnancySystem(),
            new SnakeMaterialSystem(),         
			new EdibleCollisionSystem(),
			new ObstacleCollisionSystem(),
			new CommandRecieveSystem(),
			new FutureErasalSystem()
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
