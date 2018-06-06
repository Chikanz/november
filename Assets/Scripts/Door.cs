using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityStandardAssets.Characters.FirstPerson;

public class Door : Interactable
{
	public IntroBonito IntroCam;

	public static event EventHandler OnLevelEnd;

	public static int loopNum;

	public Camera cam;
	public GameObject FPSCont;
	public AudioClip Locked;

	public bool isEndDoor;

	private bool fadeOnTurnAround;

	public GameObject BlackCut;
	public GameObject hallWayAudio;

	public GameObject Ocean;

	private PlayableDirector _director;
	
	// Use this for initialization
	protected override void Start ()
	{
		base.Start();
		if (GetComponent<PlayableDirector>()) _director = GetComponent<PlayableDirector>();
	}

	private void Update()
	{
		if (fadeOnTurnAround)
		{
			if (Vector3.Dot(FPSCont.transform.forward, Vector3.forward) < 0)
			{
				hallWayAudio.SetActive(false);
				BlackCut.SetActive(true);
				FPSCont.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
				Invoke("LoadOcean",5);
			}
		}
	}

	void LoadOcean()
	{
		Ocean.SetActive(true);
		transform.root.gameObject.SetActive(false); //Turn off inside
	}

	public override void Interact()
	{
		if (isEndDoor) fadeOnTurnAround = true;
		
		if (!Key.pickedUp)
		{
			if (!MyAudio.isPlaying)
			{
				MyAudio.clip = Locked;
				MyAudio.Play();
			}

			return;
		}
		
		FPSCont.SetActive(false);
		FPSCont.GetComponent<Interactor>().Resetti();
		
		cam.enabled = true;
		cam.gameObject.GetComponent<AudioListener>().enabled = true;
		
		_director.enabled = true;
		_director.Play();
	}

	/// <summary>
	/// Called from animation event passthrough
	/// </summary>
	[ContextMenu("OnEnd")]
	public void OnEnd()
	{
		#if UNITY_EDITOR
		if (!EditorApplication.isPlaying) return; //Don't play in edit
		#endif
		
		//Turn on intro cam
		IntroCam.ResettiTheSpaghetti();
		IntroCam.gameObject.SetActive(true);
		
		//Turn cam off
		cam.enabled = false;
		cam.gameObject.GetComponent<AudioListener>().enabled = false;		
						
		if (_director)
		{
			_director.time = 0;
			_director.Stop();
			_director.DeferredEvaluate();			
		}

		//Send out event
		if (OnLevelEnd != null)
		{
			loopNum++;
			OnLevelEnd(this, null);
		}
		
	}
}
