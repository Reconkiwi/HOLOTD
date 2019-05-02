using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    // Create an array of Transforms called point
    public static Transform[] points;

    void Awake() {

        // on awake, set points to equal each of the child waypoints inside of the gameobject
        // for each point, find the distance to the next point and repeat until all points have been mapped
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
            points[i] = transform.GetChild(i);
        }
    }
}
