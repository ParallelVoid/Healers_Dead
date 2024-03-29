using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LoadoutStats", menuName = "ScriptableObjects/LoadoutStats")]
public class LoadoutStats : ScriptableObject
{
    public int healthChange;
    public int manaChange;
    public int speedChange;
    public int damageChange;
    public int healChange;

    public void OnEnable()
    {
        healthChange = 0;
        manaChange = 0;
        speedChange = 0;
        damageChange = 0;
        healChange = 0;
    }

}
