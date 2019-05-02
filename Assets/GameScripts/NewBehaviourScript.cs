using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.AI;
using HoloToolkit.Unity.InputModule;

public class NewBehaviourScript : MonoBehaviour
{



    // Define Camera
    public GameObject objCamera;
    // Set Spawn Position
    private Vector3 SpawnPosition;
    // Set Distance tower spawns from camera
    private int DistanceToCamera = 1;
    // Set gameobject for different tower types
    public Transform tower;
    public Transform cannon;


    //Create and editable field called wave with a name, prefab, count and rate variable
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    // Create array of this field
    public Wave[] waves;
    // Set wave to 0
    private int nextWave = 0;

    // set search countdown to 1    
    private float searchCountdown = 1f;
    

    // Start is called before the first frame update
    void Start()
    {

        // define the objcamera as the main camera for the game
        objCamera = (GameObject)GameObject.FindWithTag("MainCamera");
        Debug.Log("attacker not active");
 


    }

 




    public void WaveCompleted()
    {

        // Find the board gameobject and disable the hand draggable script
        GameObject.Find("BOARD").GetComponent<HandDraggable>().enabled = false;
        // start the spawn agent coroutine
            StartCoroutine(SpawnAgent(waves[nextWave]));
        // Increase the wave number by 1 (next wave)
            nextWave++;


      
        // If there are no more waves, set the wave number back to 0 (restart the game)
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }

    }

    // IEnumerator required after coroutine is called - Define Wave as _wave
    IEnumerator SpawnAgent(Wave _wave)
    {
        // Depending on the wave number/count, run the spawn enemy function, repeat at the spawn rat    
        // for the wave count run the spawn enemy that many times
        for (int i = 0; i < _wave.count; i++)
        {
            // run the spawn enemy function
            SpawnEnemy(_wave.enemy);
            // wait the for the wave rate and repear
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        yield break;
    }

    // locate enemy prefab
    void SpawnEnemy (Transform _enemy)
    {
        //spawn enemy at position
        Instantiate(_enemy, transform.position, transform.rotation);
        //debug
        Debug.Log("spawning enemy: +" + _enemy.name);
    }


    // Called from the voice command 'Buy Tower'
   public void BuyTower()
    {
        //if the player had more than or equal to the worth of the tower.....
        if (PlayerStats.Money >= Tower1.towerWorth)
        {
            //the players money is reduced by the cost of the tower
            PlayerStats.Money -= Tower1.towerWorth;
            // Spawn the tower in front of the camera 
            SpawnPosition = objCamera.transform.forward * DistanceToCamera + objCamera.transform.position;
            Instantiate(tower, SpawnPosition, Quaternion.identity);
        } else
        {
            // if else do nothing
            Debug.Log("no money!");
        }
    }

    // Called from the voice command 'Buy Tower'
    public void BuyCannon()
    {
        //the players money is reduced by the cost of the tower
        if (PlayerStats.Money >= Tower1.towerWorth)
        {
            // Spawn the tower in front of the camera 
            PlayerStats.Money -= Tower1.towerWorth;
            SpawnPosition = objCamera.transform.forward * DistanceToCamera + objCamera.transform.position;
            Instantiate(cannon, SpawnPosition, Quaternion.identity);
        }
        else
        {
            // if else do nothing
            Debug.Log("no money!");
        }
    }
}
