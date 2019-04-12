using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
	public float speed = 5;
	public float rotationSpeed = 50;
	public GameObject turret;
	string horizontalMovementAxis, verticalMovementAxis, horizontalTurretAxis;
	float horizontalMovement, verticalMovement, horizontalTurret;
	Rigidbody rb;

    public float turretYRotation = 0f;

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
        horizontalMovement = Input.GetAxis(tankStats.playerId.ToString() + "_HM"); //Input.GetAxis("Horizontal");// CheapJoyStickHack(Input.GetAxis(tankStats.playerId.ToString() + "_HM"), 0.1f);
        verticalMovement = -Input.GetAxis(tankStats.playerId.ToString() + "_VM"); //Input.GetAxis("Vertical");//CheapJoyStickHack(-Input.GetAxis(tankStats.playerId.ToString() + "_VM"), 0.1f);
        horizontalTurret = Input.GetAxis(tankStats.playerId.ToString() + "_TR"); //CheapJoyStickHack(Input.GetAxis(tankStats.playerId.ToString() + "_TR"), 0.4f);

        if (turret )
		{
            float turretRotation = horizontalTurret * 80f * Time.deltaTime;
            Debug.Log(gameObject.name + " " + Mathf.Sign(horizontalTurret));


            turretYRotation += horizontalTurret * 80f * Time.deltaTime;
            Quaternion tr = Quaternion.Euler(0f, turretRotation, 0f);
            //turret.transform.localRotation *= Quaternion.identity;

            turret.transform.localRotation *= tr;

         

		}

	}

	// Update is called once per frame
	void FixedUpdate()
    {
		
		Vector3 tankMovement = transform.forward * verticalMovement * speed * Time.deltaTime;
		rb.MovePosition(rb.position + tankMovement);


		float tankRotation = horizontalMovement * rotationSpeed * Time.deltaTime;
		Quaternion deltarotation = Quaternion.Euler(0f, tankRotation, 0f);
		rb.MoveRotation(rb.rotation * deltarotation);

        /*
       if (turret && turret.GetComponent<Rigidbody>() != null)
       {
           float turretRotation = horizontalTurret * rotationSpeed * Time.deltaTime;
           Quaternion tr = Quaternion.Euler(0f, turretRotation, 0f);
           turret.GetComponent<Rigidbody>().MoveRotation(turret.GetComponent<Rigidbody>().rotation * tr);
       }

       if (Input.GetKey(KeyCode.W))
       {
           rb.AddForce(transform.forward * speed);
       }
       if (Input.GetKey(KeyCode.S))
       {
           rb.AddForce(transform.forward * -speed);
       }
       if (Input.GetKey(KeyCode.A))
       {
           rb.MoveRotation(rb.rotation * deltarotation);
       }
       if (Input.GetKey(KeyCode.D))
       {
           rb.MoveRotation(rb.rotation * minusDeltarotaion);
       }*/
    }

    float CheapJoyStickHack(float _inputAxis, float _errorCorrection)
    {
        if (_inputAxis > _errorCorrection || _inputAxis < -_errorCorrection)
            return _inputAxis;
        else
            return 0f;
    }
}
