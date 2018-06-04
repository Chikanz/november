using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// This class has two instances linked by static references lmaoooooooooooooooooooo 
/// </summary>
public class DoorCamera : Interactable
{
	public IntroBonito IntroCam;

	public static event EventHandler OnLevelEnd;

	public Camera cam;
	public GameObject FPSCont;

	private static PlayableDirector _director; //Yeah NOICE
	
	// Use this for initialization
	void Start ()
	{
		if (GetComponent<PlayableDirector>()) _director = GetComponent<PlayableDirector>();
	}	

	public override void Interact()
	{
		FPSCont.SetActive(false);
		FPSCont.GetComponent<Interactor>().Resetti();
		
		cam.enabled = true;
		cam.gameObject.GetComponent<AudioListener>().enabled = true;
		
		GetComponent<PlayableDirector>().Play();
	}

	/// <summary>
	/// Called from animation event
	/// </summary>
	[ContextMenu("OnEnd")]
	public void OnEnd()
	{
		if (!EditorApplication.isPlaying) return; //Don't play in edit
		
		//Turn on intro cam
		IntroCam.ResettiTheSpaghetti();
		IntroCam.gameObject.SetActive(true);
		
		//Turn me off
		cam.enabled = false;
		cam.gameObject.GetComponent<AudioListener>().enabled = false;

		_director.time = 0; //Reset playable
		_director.Stop();

		//Send out event
		if (OnLevelEnd != null)
		{
			OnLevelEnd(this, null);
		}
		
	}
}
