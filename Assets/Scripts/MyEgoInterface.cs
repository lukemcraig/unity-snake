using UnityEngine;
using System.Collections.Generic;

public class MyEgoInterface : EgoInterface
{
	static MyEgoInterface()
	{
		//        Add Systems here:
        EgoSystems.Add(
        	new CameraProjectionSystem(),
        	
        	new TickSystem(),
        	new CommandExecuteSystem(),			
			new DelayColliderSystem(),
			new AIMoverSystem(),
			new TimeInputSystem(),
			new MovementInputSystem(),
			//new TestRightSystem(),
			new SnakeHeadMovementSystem(),
			new MovementSystem(),
			new SnakeParentMovementSystem(),
			new AgeSystem(),			
            new SnakePregnancySystem(),
            new SnakeMaterialSystem(),         
			new EdibleCollisionSystem(),
			//new ObstacleCollisionSystem(),
			new CommandRecieveSystem(),
			new FutureErasalSystem()
			);	    
		EgoEvents.AddFront<TriggerEnterEvent>();
        EgoEvents.AddFront<TickEvent>();
        EgoEvents.AddFront<PregnancyEvent>();
        EgoEvents.AddFront<CommandEvent>();
		
		
		EgoEvents.AddEnd<ReverseTimeEvent>();
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
