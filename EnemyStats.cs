using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed = 2;
    public int MaxDist = 101;
    public int MinDist = 5;

    public Kristall kristallLeben;
    public GameObject gegner;

    public float health = 10f;
    public float damage = 10f;
    public float attackRate = 3f;
    private float nextTimeToAttack = 0f;



    private void Start()
    {
    }


    void FixedUpdate()
    {



        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            if (Vector3.Distance(transform.position, Player.position) <= MinDist && Time.time >= nextTimeToAttack)
            {
                nextTimeToAttack = Time.time + 1f / attackRate;
                Attack();
            }
            else if (Vector3.Distance(transform.position, Player.position) >= MinDist)
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }

        }

    }
    public void takeDamage(float amount)
    {
        health = health - amount;
        if (health <= 0f)
        {
            print("DAMAGE");
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Attack()
    {
        kristallLeben.currentHealth = kristallLeben.currentHealth - damage;
        kristallLeben.TakeDamage(damage);
    }

}