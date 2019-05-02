using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    // define number of lives
    public static int Lives;
    public int startLives = 5;

    // define starting money
    public static int Money;
    public int startMoney = 400;


    // Start is called before the first frame update
    void Start()
    {
        // Set lives, set money
        Lives = startLives;
        Money = startMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
