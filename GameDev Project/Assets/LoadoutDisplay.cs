using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadoutDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthoutput;
    public TextMeshProUGUI manaoutput;
    public TextMeshProUGUI speedoutput;
    public TextMeshProUGUI damageoutput;
    public TextMeshProUGUI healoutput;
    public TextMeshProUGUI skillpoints;
    
    public Loadout loadout;
    public LoadoutStats loadoutstats;

    void Start()
    {
        // output.text = "current health change: " + loadoutstats.healthChange.ToString();
    }

    void Update()
    {
        if (this != null)
        {
            healthoutput.text = "current health change: " + loadoutstats.healthChange.ToString();
            manaoutput.text = "current mana change: " + loadoutstats.manaChange.ToString();
            speedoutput.text = "current speed change: " + loadoutstats.speedChange.ToString();
            damageoutput.text = "current damage change: " + loadoutstats.damageChange.ToString();
            healoutput.text = "current heal change: " + loadoutstats.healChange.ToString();

            skillpoints.text = loadout.skillPoints.ToString();
        }
        
    }
}
