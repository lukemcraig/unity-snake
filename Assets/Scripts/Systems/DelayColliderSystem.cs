using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayColliderSystem: EgoSystem<
EgoConstraint<DelayColliderComponent, BoxCollider>
>{
	public override void Update()
	{      
		constraint.ForEachGameObject( ( egoComponent, delayer, collider ) =>
			{
				Debug.Log("hi");
				collider.enabled=false;
				delayer.StartCoroutine(EnableCollider(collider,delayer.delayTime));
				Ego.DestroyComponent<DelayColliderComponent>(egoComponent);
			} );
	}

	IEnumerator EnableCollider(Collider collider, float delay){
		yield return new WaitForSecondsRealtime (delay);
		collider.enabled = true;
		yield break;
	}
}
