using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class IntroBonito : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject FPS;
    public GameObject FakeWall;
    public GameObject Door;

    public GameObject BreakingIn;

    public Interactable Lamp;

    public GameObject[] Lights;

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResettiTheSpaghetti()
    {
        ToggleObjects(false);
    }

    /// <summary>
    /// Called on animation event
    /// </summary>
    public void EndOfIntro()
    {
        #if UNITY_EDITOR
        if(!EditorApplication.isPlaying) return;
        #endif
        
        ToggleObjects(true);

        if (global::Door.loopNum == 2)
        {
            Invoke("Banging",11);
            Invoke("Run",15);
        }
        
    }
    
    //End game
    private void Run()
    {
        Canvas.SetActive(true);
        FPS.GetComponent<FirstPersonController>().m_WalkSpeed = 9;
        Invoke("ToggleCanvasOff", 0.5f);
        FakeWall.transform.Translate(-2.7f,0,0);
        Door.SetActive(false);

        foreach (GameObject g in Lights)
        {
            g.SetActive(true);
        }
    }

    void Banging()
    {
        BreakingIn.SetActive(true);
    }

    private void ToggleCanvasOff()
    {
        Canvas.SetActive(false);
    }
    

    void ToggleObjects(bool on)
    {        
        FPS.SetActive(on);
        GetComponent<Camera>().enabled = !on;
        gameObject.SetActive(!on);
    }

    public void ToggleLamp()
    {
        Lamp.Interact();
    }
}
