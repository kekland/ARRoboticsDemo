using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

	[SerializeField]
	private GameObject attachedShaft;
	private Rigidbody shaftRigidbody;
	void Start () {
		shaftRigidbody = attachedShaft.GetComponent<Rigidbody>();
	}
	
	void Update () {
		shaftRigidbody.AddRelativeTorque(new Vector3(0f, 0f, 1f), ForceMode.Force);
	}
}
