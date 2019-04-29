using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PowerUps : MonoBehaviour
{

    SphereCollider sphereCollider;
    public delegate void Touched(GameObject _sender, GameObject _target);
    public static event Touched OnPickedUp;
    public bool destroyOnTrigger = true;

    void Awake()
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
            if(destroyOnTrigger)
                Destroy(gameObject);
        }
    }

    public void DisableAllColliders()
    {
        Collider[] allColliders = GetComponentsInChildren<Collider>();

        for (int i = 0; i < allColliders.Length; i++)
        {
            allColliders[i].enabled = false;
        }
    }

    public void DisableAllMeshRenders()
    {
        MeshRenderer[] allRenders = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < allRenders.Length; i++)
        {
            allRenders[i].enabled = false;
        }
    }

    void Update()
    {
        
    }
}
