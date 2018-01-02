using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class SnakePartComponent : MonoBehaviour {

	public bool isPregnant = false;
	//public SnakePartComponent parentPart;
	public SnakePartComponent childPart;
	public GameObject snakePrefab;
	public Material pregnantMaterial;
	public Material normalMaterial;
	public Material newMaterial;
	public Material headMaterial;
	public Transform container;
}
