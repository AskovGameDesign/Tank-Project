using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePortGameMode : MonoBehaviour
{

    public Tank tankScript;

    // Start is called before the first frame update
    void Start()
    {
        tankScript = GetComponentInParent<Tank>();
    }

    private void OnEnable()
    {
        GameManager.OnTankDied += GameManager_OnTankDied;
    }

    private void OnDisable()
    {
        GameManager.OnTankDied -= GameManager_OnTankDied;
    }

    private void GameManager_OnTankDied(Tank tankWhoShot, Tank tankWhoDied)
    {
        if (tankScript && tankWhoShot == tankScript)
        {  
			tankScript.tankBase.transform.position = tankWhoDied.tankBase.transform.position;    
        }
    }
}
