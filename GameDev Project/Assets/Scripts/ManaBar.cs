using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    public Slider slider1;

    public void SetMaxMana(int mana) {
        slider1.maxValue = mana;
        slider1.value = mana;
    }

    // Start is called before the first frame update
    public void SetMana(int mana) {
        slider1.value = mana;
    }
}
