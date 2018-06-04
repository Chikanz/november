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

    AudioSource _myAudio;
    [NotNull] [SerializeField] private AudioClip RingingClip;

    public override void Interact()
    {
        if(!isOn)
        {
            isOn = true;
            Reciever.SetActive(false);
            _myAudio.Stop(); //Stop ringing

            _myAudio.PlayOneShot(Pickup);

            Invoke("PlayTone", 0.5f);
        }
        else
        {
            Reciever.SetActive(true);
            isOn = false;
            _myAudio.Stop();
            _myAudio.PlayOneShot(Putdown);
        }
    }

    private void PlayTone()
    {
        _myAudio.clip = Tone;
        _myAudio.Play();
    }

    private void Ring()
    {    
        _myAudio.clip = RingingClip;
        _myAudio.Play();
    }

    // Use this for initialization
    protected override void Start()
    {
        _myAudio = GetComponent<AudioSource>();
        Ring();
        
        DoorCamera.OnLevelEnd += DoorCameraOnOnLevelEnd;
    }

    private void DoorCameraOnOnLevelEnd(object sender, EventArgs e)
    {
        Ring();
    }
}
