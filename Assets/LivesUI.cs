using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{

    public Text livesText;

    // Update is called once per frame
    void Update()
    {
        // converts lives into string
        livesText.text = "LIVES: " + PlayerStats.Lives.ToString();
    }
}
