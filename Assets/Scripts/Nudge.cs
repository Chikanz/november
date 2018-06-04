using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;
using Random = UnityEngine.Random;

public class Nudge : MonoBehaviour
{
	private float _positionNudge = 0.15f;
	private float _rotationNudge = 8;

	private Vector3 _startPos;
	private Quaternion _startRot;
	
	// Use this for initialization
	void Start () 
	{
		DoorCamera.OnLevelEnd += DoorCameraOnOnLevelEnd;
		_startPos = transform.position;
		_startRot = transform.rotation;	
	}

	private void DoorCameraOnOnLevelEnd(object sender, EventArgs e)
	{			
		transform.position = new Vector3(
			_startPos.x + Random.Range(-_positionNudge, _positionNudge),
			_startPos.y,
			_startPos.z + Random.Range(-_positionNudge, _positionNudge)
			);
		
		transform.rotation = _startRot * Quaternion.Euler(Vector3.up * Random.Range(-_rotationNudge, _rotationNudge));
	}

	// Update is called once per frame
	void Update () {
		
	}
}
