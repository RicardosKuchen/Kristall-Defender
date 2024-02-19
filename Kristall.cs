using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kristall : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float dot = 1f;

    public UIHealth kristallHp;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        kristallHp.SetMaxHealth(maxHealth);
        StartCoroutine(DamageOverTime());

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        print("ahahahahaha");
    }

    IEnumerator DamageOverTime()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(0.1f);
            currentHealth = currentHealth - dot;
            kristallHp.SetHealth(currentHealth);
        }
        
    }
}
