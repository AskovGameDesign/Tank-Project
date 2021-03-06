﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float speed = 15;
	public int damageGiven = 1;

	public GameObject explosionPrefab;
	Rigidbody rb;
	Vector3 projectileDirection;
	Collider col;
	Vector3 hitNormal, hitPoint, newProjectileDirection;
	bool updateProjectile = true;

    Tank shooter;

    public Tank Shooter
    {
        get
        {
            return shooter;
        }

        set
        {
            shooter = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();

		projectileDirection = transform.forward;

		col = GetComponent<Collider>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
		if (updateProjectile)
		{
			rb.velocity = projectileDirection * speed;
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
		ContactPoint cp = collision.contacts[0];

        hitNormal = cp.normal;
        hitPoint = cp.point;

        if (cp.otherCollider.CompareTag("Player"))
		{
			GameObject explosion = Instantiate(explosionPrefab, cp.thisCollider.transform.position, Quaternion.identity);
            Explosion explodeScript = explosion.GetComponent<Explosion>();

            Tank tankWhoGotHit = cp.otherCollider.GetComponentInParent<Tank>();
            if (tankWhoGotHit)
                tankWhoGotHit.tankWhoShotMe = shooter;

            explodeScript.Explode(hitPoint);
            Destroy(gameObject);
        }
		
		col.enabled = false;
		updateProjectile = false;

		newProjectileDirection = Vector3.Reflect(projectileDirection.normalized, hitNormal.normalized);

		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		transform.forward = newProjectileDirection;
		projectileDirection = newProjectileDirection;
		updateProjectile = true;
		StartCoroutine(EnableCollider(0.1f));

    }
	IEnumerator EnableCollider(float _delay)
	{
		yield return new WaitForSeconds(_delay);
		col.enabled = true;
	}

    

}
