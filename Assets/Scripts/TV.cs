using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Interactable
{
    public GameObject PlaneOn;
    public GameObject PlaneOff;
    public GameObject Escape;

    public AudioClip Switch;

    public override void Interact()
    {
        if(!CanInteract) return;
        
        IsOn = !IsOn;        

        PlaneOff.SetActive(!IsOn);
        PlaneOn.SetActive(IsOn);

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().PlayOneShot(Switch,1);
    }

    protected override void OnLevelEnd(int i)
    {
        base.OnLevelEnd(i);
        if (i == 1)
        {
            CanInteract = false;            
        }              
        
        Escape.SetActive(false);
    }


    public void TurnOnEscape()
    {
        Escape.SetActive(true);
    }
}
