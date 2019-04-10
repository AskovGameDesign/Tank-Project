using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class RepairPowerUp : MonoBehaviour
{
	public GameObject onPickUpMagickStuffPrefab;
	public int repairAmount = 1;
	private SphereCollider sphereCollider;


    // Start is called before the first frame update
    void Start()
    {
		sphereCollider = GetComponent<SphereCollider>();
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Tank>())
		{
			other.GetComponent<Tank>().health += repairAmount;
			//her instantiatter vi onPickUpMagickStuffPrefab;
			Destroy(gameObject);
		}
	}
}