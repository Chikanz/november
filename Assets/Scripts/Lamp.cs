using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Lamp : Interactable
{
    public GameObject EmissionObj;

    public Color EmissionColor;    
    
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        ToggleLight();        
    }

    public override void Interact()
    {
        IsOn = !IsOn;

        GetComponent<PlayableDirector>().Play();
        Invoke("ToggleLight", 0.15f);
    }

    void ToggleLight()
    {
        GetComponentInChildren<Light>().enabled = IsOn;
        EmissionObj.GetComponent<Renderer>().material.SetColor("_EmissionColor", IsOn ? EmissionColor : Color.black);
        UpdateProbe.OnOnLightChanged();
    }



}
