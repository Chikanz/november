using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Phone : Interactable
{
    public GameObject Reciever;
    public AudioClip Pickup;
    public AudioClip Tone;
    public AudioClip Putdown;    
    
    [NotNull] [SerializeField] private AudioClip RingingClip;

    public override void Interact()
    {
        if (!CanInteract) return;
        
        if(!IsOn)
        {
            IsOn = true;
            Reciever.SetActive(false);
            MyAudio.Stop(); //Stop ringing

            MyAudio.PlayOneShot(Pickup);

            Invoke("PlayTone", 0.5f);
        }
        else
        {
            Reciever.SetActive(true);
            IsOn = false;
            MyAudio.Stop();
            MyAudio.PlayOneShot(Putdown);
        }
    }

    private void PlayTone()
    {
        MyAudio.clip = Tone;
        MyAudio.Play();
    }

    private void Ring()
    {    
        MyAudio.clip = RingingClip;
        MyAudio.Play();
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();        
        Ring();
    }

    protected override void OnLevelEnd(int i)
    {
        base.OnLevelEnd(i);
        Ring();

        if (i == 2)
        {
            CanInteract = false;
            Reciever.SetActive(false);
        }
        
    }
}
