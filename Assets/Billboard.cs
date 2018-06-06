using UnityEngine;

public class Billboard : MonoBehaviour
{
	void Update() 
	{
		transform.LookAt(Camera.main.transform.position, -Vector3.up);
	}
}