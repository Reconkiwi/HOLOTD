using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    //Enemy Stats
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int worth = 50;

    // enemy death animation
    public GameObject deathEffect;


    // enemy is not dead on instantiation
    private bool isDead = false;

    void Start()
    {
        // speed = speed, health = health
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        // health is reduced by damage
        health -= amount;


        // if health reaches 0 then die
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }


    void Die()
    {
        // dead is true
        isDead = true;
        // play death animation
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        // increase money by enemy worth
        PlayerStats.Money += worth;
        // destroy gameobject   
        Destroy(gameObject);
    }

}