using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var colliders = Physics.OverlapSphere(transform.position, 2);

            float highestDot = -1;
            int DotIndex = -1;

            for (int i = 0; i < colliders.Length; i++)
            {
                var interactable = colliders[i].gameObject.GetComponent<Interactable>();
                if(interactable)
                {
                    var v = colliders[i].transform.position - transform.position;
                    var dot = Vector3.Dot(transform.forward, v.normalized);
                    if(dot > highestDot)
                    {
                        highestDot = dot;
                        DotIndex = i;
                    }
                }
            }
            //If we found an interactable
            if(DotIndex != -1) colliders[DotIndex].gameObject.GetComponent<Interactable>().Interact();
        }
	}    
}
