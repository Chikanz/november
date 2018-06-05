using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public abstract class Interactable : MonoBehaviour 
{
	[HideInInspector]
	public bool IsOn;

	protected AudioSource MyAudio;
	protected bool CanInteract = true;

	// Use this for initialization
	protected virtual void Start () 
	{
		DoorCamera.OnLevelEnd += DoorCameraOnOnLevelEnd;
		MyAudio = GetComponent<AudioSource>();
	}

	private void DoorCameraOnOnLevelEnd(object sender, EventArgs e)
	{
		if(IsOn) Interact();
		OnLevelEnd(DoorCamera.loopNum);
	}

	/// <summary>
    /// Called when the player interacts with this object
    /// </summary>
    public abstract void Interact();

	/// <summary>
	/// Allows kiddos to hook into end level event
	/// </summary>
	/// <param name="i">Iteration of the loop</param>
	protected virtual void OnLevelEnd(int i)
	{
		
	}
	
}
