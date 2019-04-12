using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform barrelEnd;
    public int bulletSpeed = 300;
    public float fireRate = 0.5f;
    float timeSinceLastShot;
    float t;

	Tank tankStats;

    private void Start()
    {
        timeSinceLastShot = fireRate;
		tankStats = GetComponentInParent<Tank>();
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

            timeSinceLastShot = t;
        }

        t += Time.deltaTime;
    }
}