using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower1 : MonoBehaviour
{
    [Header("Unity Setups")]

    //Create Target variable
    public Transform target;
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;
    public AudioSource audioSource;

    [Header("Attributes")]
    // Variables for towers
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range = 15f;
    public int worth = 200;
    public static int towerWorth;

    // Start is called before the first frame update
    void Start()
    {
        towerWorth = worth;
        //Repeat the update target function like this to reduce latency
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        audioSource = GetComponent<AudioSource>();
    }


    // Find target
    void UpdateTarget()
    {
        // Find the enemy with the tag 'Enemy'
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        // The shortest distance is infinite
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // For each enemy
        foreach (GameObject enemy in enemies)
        {
            //find the distance between the enemy and tower and set enemy to target
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //if enemy is within range then targert is the enemy
        // if not, there is noi target
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if targer is null dom nothing
        if (target == null)
        {
            return;
        }

        // if target exists and countdown is 0 then shoot and countdown
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        // Draw gizmo according to range size
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        //Instanciate bullets at firepoint (tower)
       GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        // if a bullet exists, move to target and play audio.
        if (bullet != null)
        {
            audioSource.Play();
            bullet.Seek(target);
        }
    }
}
