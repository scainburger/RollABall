﻿using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
		// Time.deltaTime Makes it framerate independant, therefore smoother
	}
}
