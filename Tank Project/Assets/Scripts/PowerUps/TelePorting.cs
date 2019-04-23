using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePorting : MonoBehaviour
{

	public GameObject destination;


	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.transform.position = destination.transform.position;
		}
	}


	// Update is called once per frame
	void Update()
    {
        
    }
}
