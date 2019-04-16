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
    public void Start()
    {
		sphereCollider = GetComponent<SphereCollider>();
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponentInParent<Tank>())
		{
            other.GetComponentInParent<Tank>().TakeDamage(repairAmount);
			//her instantiatter vi onPickUpMagickStuffPrefab;
			Destroy(gameObject);
		}
	}
}