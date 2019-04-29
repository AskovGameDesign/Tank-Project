using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFire : PowerUps
{

    public float newFireRate = 0.2f;
    public float activeTime = 5f;
    private Shooting targetTankShootingScript;

    void Start()
    {
        destroyOnTrigger = false;
    }


    private void OnEnable()
    {
        PowerUps.OnPickedUp += FireRateUp;
    }

    private void OnDisable()
    {
        PowerUps.OnPickedUp -= FireRateUp;
    }

    void FireRateUp(GameObject sender, GameObject target)
    {
        if (sender == gameObject)
        {
            target.GetComponentInParent<Shooting>().fireRate = newFireRate;
            targetTankShootingScript = target.GetComponentInParent<Shooting>();
            Invoke("DestroyMe", activeTime);
            DisableAllColliders();
            DisableAllMeshRenders();
        }
    }

    void DestroyMe()
    {
        if (targetTankShootingScript)
            targetTankShootingScript.ResetFireRate();

        Destroy(gameObject);
    }
}
