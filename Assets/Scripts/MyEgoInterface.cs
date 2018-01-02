using UnityEngine;
using System.Collections.Generic;

public class MyEgoInterface : EgoInterface
{
	static MyEgoInterface()
	{
		//        Add Systems here:
        EgoSystems.Add(
        	//new CameraProjectionSystem(),
			//new AutoCamSystem(),

        	new TickSystem(),
        	//new TurnBasedTickSystem(),
        	new CommandExecuteSystem(),			
			new DelayColliderSystem(),

			new AgeSystem(),			
			new SnakePregnancySystem(),
			new SnakeMaterialSystem(), 

			//new AIMoverSystem(),
			new TimeInputSystem(),
			new MovementInputSystem(),
			//new TestRightSystem(),

			new SnakeHeadMovementSystem(),
			new SnakeParentMovementSystem(),
            new MovementSystem(),

            new EdibleCollisionSystem(),
			new ObstacleCollisionSystem(),

			new CommandRecieveSystem(),
			new FutureErasalSystem()
			);	   
		EgoEvents.AddFront<ReverseTimeEvent>();
		EgoEvents.AddFront<TriggerEnterEvent>();
        EgoEvents.AddFront<TickEvent>();        
        EgoEvents.AddFront<CommandEvent>();
        EgoEvents.AddFront<PregnancyEvent>();
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
