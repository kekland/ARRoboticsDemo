using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

	[SerializeField]
	private GameObject attachedShaft;
	private Rigidbody shaftRigidbody;

	[SerializeField]
	private float MaximumTorqueAmount;

	[SerializeField]
	private float CurrentTorque;

	[SerializeField]
	private float MaximumAngularVelocity;

	[SerializeField]
	private bool isReversed = false;
	float acceleration;
	void Start () {
		if(attachedShaft == null) {
			return;
		}
		shaftRigidbody = attachedShaft.GetComponent<Rigidbody>();

		MaximumTorqueAmount = GameObject.Find("Config").GetComponent<WorldConfig>().MaximumTorqueInMotors;
		MaximumAngularVelocity = GameObject.Find("Config").GetComponent<WorldConfig>().MaximumAngularSpeedInMotors;
	}
	
	void FixedUpdate() {
		if(attachedShaft == null || shaftRigidbody == null) {
			return;
		}

		if(CurrentTorque == 0f) {
			shaftRigidbody.angularVelocity = Vector3.zero;
		}
		else {
			shaftRigidbody.AddRelativeTorque(0f, 0f, CurrentTorque);
		}
		shaftRigidbody.maxAngularVelocity = MaximumAngularVelocity;
	}

	public void SetTorque(float torqueMultiplier) {
		if(isReversed) {
			torqueMultiplier *= -1;	
		}
		CurrentTorque = torqueMultiplier * MaximumTorqueAmount;
	}
}
