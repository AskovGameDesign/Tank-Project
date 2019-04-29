using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform barrelEnd;
    public int bulletSpeed = 15;
    public float fireRate = 0.5f;
    float timeSinceLastShot;
    float t;

    private int defaultBulletSpeed;
    private float defaultFireRate;

	Tank tankStats;

    private void Start()
    {
        timeSinceLastShot = fireRate;
		tankStats = GetComponentInParent<Tank>();
        defaultBulletSpeed = bulletSpeed;
        defaultFireRate = fireRate;
    }

    void Update()
    {
		if (tankStats == null)
		{
			return;
		}

		if (Input.GetButtonDown(tankStats.playerId.ToString() + "_Fire") && t - timeSinceLastShot >= fireRate)
        {
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(bulletPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            bulletInstance.GetComponent<Projectile>().speed = bulletSpeed;
            bulletInstance.GetComponent<Projectile>().Shooter = tankStats;

            timeSinceLastShot = t;
        }

        t += Time.deltaTime;
    }

    public void ResetBulletSpeed()
    {
        bulletSpeed = defaultBulletSpeed;
    }

    public void ResetFireRate()
    {
        fireRate = defaultFireRate;
    }
}