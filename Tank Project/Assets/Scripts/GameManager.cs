using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMPro.TMP_Text winnerText;

    Tank[] tanks;
    List<Tank> allTanks = new List<Tank>();
    
    // Start is called before the first frame update
    void Start()
    {
        tanks = FindObjectsOfType<Tank>();

        foreach (var t in tanks)
        {
            allTanks.Add(t);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public string GetWinnerName()
    {
        if (allTanks.Count == 1)
        {
            return allTanks[0].PlayerName();
        }
        else
            return "DRAW";
    }

    public void TankDied(Tank _tank)
    {
        allTanks.Remove(_tank);

        if (allTanks.Count == 1)
        {
            // Only onetank alive
            Debug.Log("Winner tank is " + allTanks[0].playerId);

            winnerText.gameObject.SetActive(true);
            winnerText.text = "Match winner " + GetWinnerName();
        }

        
    }
}
