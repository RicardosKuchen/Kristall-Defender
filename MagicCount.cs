using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicCount : MonoBehaviour
{
    Text instruction;
    public PlayerMovmentScript value;

    // Start is called before the first frame update
    void Update()
    {
        value = GameObject.Find("Player").GetComponent<PlayerMovmentScript>();
        instruction = GetComponent<Text>();
        instruction.text = value.magicCount.ToString();
    }
}
