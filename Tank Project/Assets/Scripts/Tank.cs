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
    public GameObject tankBase;
	public GameObject diePrefab;

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int amount)
	{
		health += amount;

		if (health <= 0)
		{
			Die();
		}

        gameManager.UpdateUIText();
	}

	public string PlayerName()
    {
        if (playerId == PlayerId.P1)
            return "Player 1";
        else if (playerId == PlayerId.P2)
            return "Player 2";
        else if (playerId == PlayerId.P3)
            return "Player 3";
        else if (playerId == PlayerId.P4)
            return "Player 4";
        else
            return "Player 100";

    }

	void Die()
	{
        if (tankBase == null)
            return;

        Instantiate(diePrefab, tankBase.transform.position, Quaternion.identity);

        if (gameManager) gameManager.TankDied(this);

		Destroy(gameObject);
	}
		
}
