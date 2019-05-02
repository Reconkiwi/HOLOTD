using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        // if the player had no more lives then end game
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        //restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
