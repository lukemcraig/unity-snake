using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatEdibleCommand : ICommand {
	
	public EgoComponent edible;
	public EgoComponent mouth;
	
	public EatEdibleCommand(EgoComponent edible,EgoComponent mouth){
		this.edible = edible;
		this.mouth = mouth;
	}
	
	public override void Execute(){
		Ego.DestroyGameObject (edible);
		SnakePartComponent snakePart;
		if (mouth.TryGetComponents (out snakePart)) {
            snakePart.isPregnant = true;
            var pregEvent = new PregnancyEvent(snakePart);
            EgoEvents<PregnancyEvent>.AddEvent(pregEvent);
        }
	}
	
	public override void Undo(){
		
	}
}
