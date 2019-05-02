using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class Attackermove : MonoBehaviour
{
    // Set player speed
    public float speed = 0.1f;
    // deine target
    private Transform target;
    private int wavepointIndex = 0;
    //set wavepoint index to 0
    void Start()
    { 
        // Set the target to the waypoints array
        target = Waypoints.points[0];
    }

    void Update()
    {
        //transform towards target waypoint ( from 0 up ) inside of world space
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        // iF the distance between the enemy and waypoint is less than 0.01f then locate next waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.01f)
        {
            GetNextWaypoint();
        }
    }
    // if there are no motre waypoints run end path function
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1) {

            EndPath();
        }

        // if not the target is changed to the next waypoint
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    // reduce player life by one and destroy gameobject  
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}

