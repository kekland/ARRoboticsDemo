using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cortex : MonoBehaviour {

	[SerializeField]
	private Motor[] Motors;

	//[SerializeField]
	//private Sensor[] Sensors;

	[SerializeField]
	private string Code;

	void FixedUpdate() {
		//User-defined code here
		if(Input.GetKey(KeyCode.W)) {
			Motors[0].SetTorque(1.0f);
			Motors[1].SetTorque(1.0f);
			Motors[2].SetTorque(1.0f);
			Motors[3].SetTorque(1.0f);
		}
		else if(Input.GetKey(KeyCode.S)) {
			Motors[0].SetTorque(-1.0f);
			Motors[1].SetTorque(-1.0f);
			Motors[2].SetTorque(-1.0f);
			Motors[3].SetTorque(-1.0f);
		}
		else if(Input.GetKey(KeyCode.A)) {
			Motors[0].SetTorque(-1.0f);
			Motors[1].SetTorque(-1.0f);
			Motors[2].SetTorque(1.0f);
			Motors[3].SetTorque(1.0f);
		}
		else if(Input.GetKey(KeyCode.D)) {
			Motors[0].SetTorque(1.0f);
			Motors[1].SetTorque(1.0f);
			Motors[2].SetTorque(-1.0f);
			Motors[3].SetTorque(-1.0f);
		}
		else {
			Motors[0].SetTorque(0f);
			Motors[1].SetTorque(0f);
			Motors[2].SetTorque(0f);
			Motors[3].SetTorque(0f);
		}

		if(Input.GetKey(KeyCode.U)){ 
			Motors[4].SetTorque(1.0f);
		}
		else if(Input.GetKey(KeyCode.J)) {
			Motors[4].SetTorque(-1.0f);
		}
		else {
			Motors[4].SetTorque(0f);
		}
	}
}
