using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RobotConstructor : MonoBehaviour {

	public List<GameObject> Prefabs;
	public int currentSelectedPrefab;

	public GameObject selectedPrefab;
	GameObject attachedObject;
	float yOffset = 0f;
	void Start () {
		ChangeSelectedPrefab(false);
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			if(currentSelectedPrefab != Prefabs.Count - 1) {
				currentSelectedPrefab++;
				ChangeSelectedPrefab(true);
			}
		}	
		else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			if(currentSelectedPrefab != 0) {
				currentSelectedPrefab--;
				ChangeSelectedPrefab(true);
			}
		}

		RaycastHit hit;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
			Vector3 rawPosition = hit.point;
			
			rawPosition.x = (float)Math.Round(rawPosition.x, 1);
			rawPosition.y = (float)Math.Round(rawPosition.y, 1);
			rawPosition.z = (float)Math.Round(rawPosition.z, 1);

			rawPosition.y += selectedPrefab.GetComponent<Collider>().bounds.size.y / 2f + yOffset;

			attachedObject = hit.collider.gameObject;
			selectedPrefab.transform.position = rawPosition;
		}

		if(Input.GetMouseButtonDown(0)) {
			selectedPrefab.GetComponent<Rigidbody>().detectCollisions = true;
			selectedPrefab.GetComponent<Rigidbody>().isKinematic = false;
			Debug.Log(selectedPrefab.transform.position);

			attachedObject.AddComponent<FixedJoint>().connectedBody = selectedPrefab.GetComponent<Rigidbody>();
			ChangeSelectedPrefab(false);
		}

		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			yOffset += 0.1f;
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			yOffset -= 0.1f;
		}
	}

	void ChangeSelectedPrefab(bool destroy) {
		if(destroy) {
			Destroy(selectedPrefab);
		}
		selectedPrefab = null;
		selectedPrefab = Instantiate(Prefabs[currentSelectedPrefab]);
		selectedPrefab.GetComponent<Rigidbody>().detectCollisions = false;
		selectedPrefab.GetComponent<Rigidbody>().isKinematic = true;
		yOffset = 0f;
	}
}
