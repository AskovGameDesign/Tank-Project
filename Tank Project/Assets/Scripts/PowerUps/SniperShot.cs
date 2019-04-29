using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperShot : PowerUps
{

    public int newBulletSpeed = 15;
    public float activeTime = 5f;
    private Shooting targetTankShootingScript;

    void Start()
    {
        destroyOnTrigger = false;
        
    }


    private void OnEnable()
    {
        PowerUps.OnPickedUp += SpeedUpShot;
    }

    private void OnDisable()
    {
        PowerUps.OnPickedUp -= SpeedUpShot;
    }

    void SpeedUpShot(GameObject sender,GameObject target)
    {
        if(sender == gameObject)
        {
            target.GetComponentInParent<Shooting>().bulletSpeed = newBulletSpeed;
            targetTankShootingScript = target.GetComponentInParent<Shooting>();
            Invoke("DestroyMe", activeTime);
            DisableAllColliders();
            DisableAllMeshRenders();
        }
    }

    void DestroyMe()
    {
        if (targetTankShootingScript)
            targetTankShootingScript.ResetBulletSpeed();

        Destroy(gameObject);
    }
}
