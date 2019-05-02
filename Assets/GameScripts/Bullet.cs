using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    // bullet variables
    private Transform target;

    public float speed = 1f;

    public int damage = 50;

    public float explosionRadius = 0f;
    //bullet impact animation
    public GameObject impactEffect;


    // the sdeek target is equal to target
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        // if there is no target destroy gameobject
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // define dir
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        //hit target
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        // transform towards target 
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget()
    {

        //play hit animation
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
        // if explosion radius is larger than 0 then explode
        if (explosionRadius > 0f)
        {
            Explode();
        } 
        // if else then damage
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    // deal damage across the explosion radius
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    // define enemy, send damage to damage script
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
