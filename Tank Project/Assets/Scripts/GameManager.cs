using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMPro.TMP_Text winnerText;
    
    
    public TankUISettings[] tankSettings;
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

        for (int i = 0; i < tankSettings.Length; i++)
        {
            tankSettings[i].Init();
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

    public void UpdateUIText()
    {
        for (int i = 0; i < tankSettings.Length; i++)
        {
            tankSettings[i].UpdateUIText();
        }
    }

    [System.Serializable]
    public class TankUISettings
    {
        public Color tankColor = Color.red;
        public string tankUIName = "Red Tank";
        public TMP_Text tankUIText;
        public Material tankMaterial;
        public Tank tankScript;

        TankUISettings()
        {

        }

        public void Init()
        {
            UpdateUIText();

            if (tankMaterial)
                tankMaterial.color = tankColor;

        }

        public void UpdateUIText()
        {
            if (tankUIText)
            {
                tankUIText.text = tankUIName + System.Environment.NewLine + "Hp = " + tankScript.health;
                tankUIText.color = tankColor;
            }
        }
           
    }
}
