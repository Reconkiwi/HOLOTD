using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    // Update is called once per frame
    void Update()
    {
        // Converts money stat into string
        moneyText.text = "£" + PlayerStats.Money.ToString();
    }
}
