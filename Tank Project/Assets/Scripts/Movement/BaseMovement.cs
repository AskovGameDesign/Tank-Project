using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
	public float speed = 5;
	public float tankRotationSpeed = 50;
    public float turretRotationSpeed = 120f;
	public GameObject turret;
	string horizontalMovementAxis, verticalMovementAxis, horizontalTurretAxis;
	float horizontalMovement, verticalMovement, horizontalTurret;
	Rigidbody rb;

	Tank tankStats;

    // Start is called before the first frame update
    void Awake()
    {
		rb = GetComponent<Rigidbody>();
		tankStats = GetComponentInParent<Tank>();
    }

	private void Update()
	{
		if(tankStats == null)
		{
			return;
		}
		
        horizontalMovement = Input.GetAxis( tankStats.playerId.ToString() + "_HM");
		verticalMovement = -Input.GetAxis( tankStats.playerId.ToString() + "_VM");
		horizontalTurret = Input.GetAxis( tankStats.playerId.ToString() + "_TR");

		if (turret)
		{
			float turretRotation = horizontalTurret * turretRotationSpeed * Time.deltaTime;
			Quaternion tr = Quaternion.Euler(0f, turretRotation, 0f);

			turret.transform.localRotation *= tr;
		}
	}

	// Update is called once per frame
	void FixedUpdate()
    {
		Vector3 tankMovement = transform.forward * verticalMovement * speed * Time.deltaTime;
		rb.MovePosition(rb.position + tankMovement);

		float tankRotation = horizontalMovement * tankRotationSpeed * Time.deltaTime;
		Quaternion deltarotation = Quaternion.Euler(0f, tankRotation, 0f);
		rb.MoveRotation(rb.rotation * deltarotation);
	}
}
