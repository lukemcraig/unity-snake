using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawn : MonoBehaviour
{
	public GameObject prefab;
	public int width = 30;
	public int wspace = 1;
	public int length = 30;
	public int lspace = 1;
	public int height = 30;
	public int hspace = 1;
	// Use this for initialization
	void OnEnable ()
	{
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < length; j++) {
				for (int k = 0; k < height; k++) {
					Instantiate (prefab, transform.position + new Vector3 (i*wspace, k*hspace, -j*lspace), Quaternion.identity, transform);
				}
			}
		}
	}

	void OnDisable(){
		for (int i = transform.childCount-1; i > 0; i--) {
			Destroy(transform.GetChild (i).gameObject);
		}
	}
	

}
