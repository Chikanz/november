using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Interactor : MonoBehaviour
{
    private Vector3 _startpos;
    private Quaternion _startRot;

    // Use this for initialization
    private void Start()
    {
        _startpos = transform.position;
        _startRot = transform.rotation;
    }
	
	// Update is called once per frame
    private void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var colliders = Physics.OverlapSphere(transform.position, 2);

            float highestDot = -1;
            int dotIndex = -1;

            for (int i = 0; i < colliders.Length; i++)
            {
                var interactable = colliders[i].gameObject.GetComponent<Interactable>();
                if (!interactable) continue;
                
                var v = colliders[i].transform.position - transform.position;
                var dot = Vector3.Dot(transform.forward, v.normalized);
                if(dot > highestDot)
                {
                    highestDot = dot;
                    dotIndex = i;
                }
            }
            //If we found an interactable and it's not behind me
            if(dotIndex != -1 && highestDot > 0) colliders[dotIndex].gameObject.GetComponent<Interactable>().Interact();
        }
	}

    [ContextMenu("Reset position")]
    public void Resetti()
    {
        transform.position = _startpos;
        var ml = GetComponent<FirstPersonController>().MouseLook; //thank you for making things easy unity papa bless
        ml.m_CharacterTargetRot = Quaternion.Euler(0, 180, 0);
        ml.m_CameraTargetRot = Quaternion.identity;
    }
}
