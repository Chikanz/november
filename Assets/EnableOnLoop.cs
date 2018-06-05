using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnLoop : MonoBehaviour
{
	public int LoopNo;
	public MonoBehaviour ToEnable;

	public AudioSource AS;

	public float ASdelay;
	
	// Use this for initialization
	void Start () 
	{
		DoorCamera.OnLevelEnd += DoorCameraOnOnLevelEnd;
		if(ToEnable) ToEnable.enabled = false;
	}

	private void DoorCameraOnOnLevelEnd(object sender, EventArgs e)
	{
		if (DoorCamera.loopNum == LoopNo)
		{
			if (ToEnable) ToEnable.enabled = true;
			if (AS) Invoke("DelayAudio", ASdelay);
		}
	}

	void DelayAudio()
	{
		AS.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
