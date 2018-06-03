using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Lamp : Interactable
{
    public bool isOn = false;

    public GameObject EmissionObj;

    public Color EmissionColor;

    public override void Interact()
    {
        isOn = !isOn;

        GetComponent<PlayableDirector>().Play();
        Invoke("ToggleLight", 0.15f);
    }

    void ToggleLight()
    {
        GetComponentInChildren<Light>().enabled = isOn;
        EmissionObj.GetComponent<Renderer>().material.SetColor("_EmissionColor", isOn ? EmissionColor : Color.black);
    }

    // Use this for initialization
    void Start ()
    {
        ToggleLight();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
