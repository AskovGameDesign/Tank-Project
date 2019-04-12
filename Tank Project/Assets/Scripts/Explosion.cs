using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

	public float explosionRadius = 3f;
	public int explosionDamage = 1;
	public float explosionForce = 2f;


    // Start is called before the first frame update
    void Explode()
    {
		Collider[] allRBSInExplosionRadius = Physics.OverlapSphere(transform.position, explosionRadius);

		foreach(Collider col in allRBSInExplosionRadius)
		{
			Rigidbody rb = col.GetComponent<Rigidbody>();
			Debug.Log("Hit " + col.name);
			if (col.CompareTag("Player") && rb != null)
			{
				rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);

				Tank tank = rb.GetComponentInParent<Tank>();

				if (tank)
				{
					tank.TakeDamage(explosionDamage);
				}
			}
		}
    }

	private void Start()
	{
		Explode();
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
