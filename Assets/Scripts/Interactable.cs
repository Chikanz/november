using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
	public bool isOn = false;

	// Use this for initialization
	protected virtual void Start () 
	{
		DoorCamera.OnLevelEnd += DoorCameraOnOnLevelEnd;
	}

	private void DoorCameraOnOnLevelEnd(object sender, EventArgs e)
	{
		if(isOn) Interact();		
	}

	/// <summary>
    /// Called when the player interacts with this object
    /// </summary>
    public abstract void Interact();	
}
