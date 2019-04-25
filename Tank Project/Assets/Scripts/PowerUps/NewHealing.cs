using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHealing : PowerUps
{
    public int repairAmount = 1;

    
    private void OnEnable()
    {
        PowerUps.OnPickedUp += Heal;
    }

    private void OnDisable()
    {
        PowerUps.OnPickedUp -= Heal;
    }

    void Heal(GameObject sender, GameObject target)
    {
        if(sender == gameObject)
        {
            target.GetComponentInParent<Tank>().TakeDamage(repairAmount);
        }

    }
    
}
