using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Key : Interactable
{
	public Transform[] Postions;
	
	public static bool pickedUp; //shhh

	public Transform playerFacing;

	private bool placeKeyWhenCan;

	private MeshRenderer MR;
	
	public override void Interact()
	{
		if (!MR.enabled) return;

		GetComponent<AudioSource>().Play();
		MR.enabled = false;
		pickedUp = true;

		if (Door.loopNum == 1)
		{
			GameObject.Find("TV").GetComponent<TV>().TurnOnEscape();
			var s = GameObject.Find("Switch").GetComponent<Switch>();
			
			if(s.IsOn) s.Interact();
		}
		
	}

	protected override void OnLevelEnd(int i)
	{
		base.OnLevelEnd(i);
		transform.position = Postions[i].position;
		pickedUp = false;
		Invoke("SetActiveDelay", Random.Range(25,40));		
		Debug.Log(i);
	}

	void SetActiveDelay()
	{
		placeKeyWhenCan = true;
	}

	protected override void Start()
	{
		base.Start();
		MR = GetComponent<MeshRenderer>();
	}

	// Place key when player not looking
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.P)) SetActiveDelay(); //For testing
		
		if (placeKeyWhenCan)
		{	
			var v = transform.position - playerFacing.transform.position;			
			if (Vector3.Dot(v.normalized, playerFacing.forward) < 0)
			{
				MR.enabled = true;
				placeKeyWhenCan = false;
			}
		}
		
	}
}
