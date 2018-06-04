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
        isOn = !isOn;
        ToggleLights(isOn);

        GetComponent<AudioSource>().PlayOneShot(SwitchClip);

        SwitchObj.rotation = Quaternion.Euler(isOn ? 80 : 0, SwitchObj.eulerAngles.y, SwitchObj.eulerAngles.z);                
    }

    private void ToggleLights(bool on)
    {        
        foreach (GameObject g in Lights)
        {
            g.SetActive(on);
        }
        
        UpdateProbe.OnOnLightChanged();
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        ToggleLights(isOn);
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
