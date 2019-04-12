using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	SpawnManager spawnManager;
	int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
		randomNumber = GetRandomNumber();
		spawnManager = FindObjectOfType<SpawnManager>();
		StartCoroutine("Spawn");
	}

	IEnumerator Spawn()
	{
		while (true)
		{
			if (transform.childCount < 1 && randomNumber <= 10)
			{


				int randomIndex = Random.Range(0, spawnManager.spawnObjects.Length);
				GameObject spawnObject = Instantiate(spawnManager.spawnObjects[randomIndex], transform.position, Quaternion.identity);
				spawnObject.transform.parent = transform;

				spawnObject.transform.localPosition = Vector3.zero;
			}
			yield return new WaitForSeconds(Random.Range(3, 20));
			randomNumber = GetRandomNumber();
		}
	}

	int GetRandomNumber()
	{
		return Random.Range(0, 51);
	}
}
