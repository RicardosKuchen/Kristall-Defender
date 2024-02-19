using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{

    public float height = 1f;
    public float speed = 0.2f;
    public float smoothness = 5f;
    int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Float(speed, count, smoothness));
    }

    IEnumerator Float(float speed, int count, float smoothness)
    {
        while (count <= 11 * smoothness)
        {
            if(count <= 5 * smoothness)
            {
                yield return new WaitForSeconds(speed / smoothness);
                Vector3 pos = transform.position;
                float newY = pos.y - height / smoothness;
                transform.position = new Vector3(pos.x, newY, pos.z);
                count = count + 1;
            }
            else if (count > 5 * smoothness && count <= 10 * smoothness)
            {
                yield return new WaitForSeconds(speed / smoothness);
                Vector3 pos = transform.position;
                float newY = pos.y + height / smoothness;
                transform.position = new Vector3(pos.x, newY, pos.z);
                count = count + 1;
            }
            else
            {
                count = 1;
            }
        }
        
    }
}
