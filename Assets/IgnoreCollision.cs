using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

	[SerializeField]
	private Collider[] List;
	void Start () {
		Collider currentCollider = GetComponent<Collider>();
		for(int i = 0; i < List.Length; i++) {
			Physics.IgnoreCollision(currentCollider, List[i]);
		}
	}
	
}
