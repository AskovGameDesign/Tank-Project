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
		if (spawnPositions == null)
			return;

		for (int i = 0; i < spawnPositions.Length; i++)
		{
			Gizmos.DrawCube(spawnPositions[i].position, Vector3.one * gizmoSize);
		}
	}
}