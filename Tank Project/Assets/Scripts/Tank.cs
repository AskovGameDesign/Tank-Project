using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
	
	public enum PlayerId
	{
		P1, P2, P3, P4
	}
	public PlayerId playerId = PlayerId.P1;

	public float health = 3;

	public GameObject diePrefab;



		public void TakeDamage(int amount)
		{
			health -= amount;
			if (health <= 0)
			{
				Die();
			}
		}

	

		void Die()
		{
		Instantiate(diePrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		
}
