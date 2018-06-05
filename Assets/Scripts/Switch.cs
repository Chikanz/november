using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public GameObject[] Lights;
    public AudioClip SwitchClip;

    public Transform SwitchObj;   

    public override void Interact()
    {
        IsOn = !IsOn;
        
        if(CanInteract) ToggleLights(IsOn);

        MyAudio.PlayOneShot(SwitchClip);

        SwitchObj.rotation = Quaternion.Euler(IsOn ? 80 : 0, SwitchObj.eulerAngles.y, SwitchObj.eulerAngles.z);                
    }

    private void ToggleLights(bool on)
    {        
        foreach (GameObject g in Lights)
        {
            g.SetActive(on);
        }
        
        UpdateProbe.OnOnLightChanged();
    }

    protected override void OnLevelEnd(int i)
    {
        base.OnLevelEnd(i);
        if(i == 2)
            CanInteract = false;
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        ToggleLights(IsOn);
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
