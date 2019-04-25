using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PowerUps : MonoBehaviour
{

    SphereCollider sphereCollider;
    public delegate void Touched(GameObject _sender, GameObject _target);
    public static event Touched OnPickedUp;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            if(OnPickedUp != null)
            {
                OnPickedUp(this.gameObject, other.gameObject);

                
            }

            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
}
