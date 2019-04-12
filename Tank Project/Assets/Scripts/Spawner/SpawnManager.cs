using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[HideInInspector]
	public Transform[] spawnPositions;
	public float gizmoSize = 2;
	public GameObject[] spawnObjects;

	private void Awake()
	{
		spawnPositions = GetComponentsInChildren<Transform>();

		for (int i = 0; i < spawnPositions.Length; i++)
		{
			if(spawnPositions[i] != this.transform)
				spawnPositions[i].gameObject.AddComponent<Spawner>();
		}
	}

	private void OnDrawGizmos()
	{

        spawnPositions = GetComponentsInChildren<Transform>();

        if (spawnPositions == null)
			return;

        Gizmos.color = new Color(0.5f, 1f, 1f, 0.5f);

        for (int i = 0; i < spawnPositions.Length; i++)
		{
            if (spawnPositions[i] != this.transform)
                Gizmos.DrawCube(spawnPositions[i].position, Vector3.one * gizmoSize);
		}
	}
}