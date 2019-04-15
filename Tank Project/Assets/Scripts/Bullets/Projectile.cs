using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float speed = 5;
	public int damageGiven = 1;


    bool canReflect = true;
	public GameObject explosionPrefab;
	Rigidbody rb;
	Vector3 projectileDirection;
	Collider collider;
	Vector3 hitNormal, hitPoint, newProjectileDirection;
	bool updateProjectile = true;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();

		projectileDirection = transform.forward;

		collider = GetComponent<Collider>();
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
			
            explodeScript.Explode(hitPoint);
            Destroy(gameObject);
        }

		
		collider.enabled = false;
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
		collider.enabled = true;
	}

    

}
