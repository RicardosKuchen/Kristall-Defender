using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player")
        {
            print("hit " + other.name + "!");
            Destroy(gameObject);

            if (other.transform.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyStats>().takeDamage(10);
            }
        }
        
        
    }

}
