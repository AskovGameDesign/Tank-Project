using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePorting : MonoBehaviour
{

	public GameObject destination;


	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" || other.tag == "Bullet")
		{
			other.transform.position = new Vector3(destination.transform.position.x, other.transform.position.y, destination.transform.position.z);
		}
	}


	// Update is called once per frame
	void Update()
    {
        
    }
}
