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
			new TestRightSystem(),
			new SnakeHeadMovementSystem(),
			new MovementSystem(),
			new SnakeParentMovementSystem(),
			//new AgeSystem(),			
            new SnakePregnancySystem(),
            //new SnakeMaterialSystem(),         
			new EdibleCollisionSystem(),
			//new ObstacleCollisionSystem(),
			new CommandRecieveSystem()
			//new FutureErasalSystem()
			);	    
		EgoEvents.AddFront<TriggerEnterEvent>();
        EgoEvents.AddFront<TickEvent>();
        EgoEvents.AddFront<CommandEvent>();
		
		
		
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
