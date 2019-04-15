using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AddToCinemachineTargetGroup : MonoBehaviour
{
    CinemachineTargetGroup cinemachineTargetGroup;

    // Start is called before the first frame update
    void Start()
    {
        cinemachineTargetGroup = FindObjectOfType<CinemachineTargetGroup>();

        BaseMovement[] tankBaseMovementScript = FindObjectsOfType<BaseMovement>();

        Debug.Log("number of tanks found " + tankBaseMovementScript.Length);

        if(cinemachineTargetGroup)
        {
            for (int i = 0; i < tankBaseMovementScript.Length; i++)
            {
                cinemachineTargetGroup.AddMember(tankBaseMovementScript[i].transform, 1f, 1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
