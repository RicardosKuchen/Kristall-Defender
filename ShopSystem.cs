using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public LayerMask mask;
    public Text WhateverTextThingy;
    private float timeToAppear = 0.05f;
    public float range = 10f;
    private float timeWhenDisappear;
    public PlayerMovmentScript magicValue;
    private int magicCost;

    //Call to enable the text, which also sets the timer
    public void EnableText()
    {
        WhateverTextThingy.enabled = true;
        timeWhenDisappear = Time.time + timeToAppear;     
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, range, mask))
        {
            var obj = hit.collider.gameObject;

            if (obj.name == "BuyCube1")
            {
                WhateverTextThingy.text = ("Damage \n 50 Magic");
                magicCost = 50;

                if (Input.GetButtonDown("Accept") && magicValue.magicCount >= magicCost)
                {
                    magicValue.magicCount = magicValue.magicCount - magicCost;
                }
            }
            else if (obj.name == "BuyCube2")
            {
                WhateverTextThingy.text = ("Damage Over Time Reduction \n 999 Magic");
                magicCost = 999;

                if (Input.GetButtonDown("Accept") && magicValue.magicCount >= magicCost)
                {
                    magicValue.magicCount = magicValue.magicCount - magicCost;
                }
            }

            Debug.Log($"looking at {obj.name}", this);
            EnableText();
        }

        if (WhateverTextThingy.enabled && (Time.time >= timeWhenDisappear))
        {
            WhateverTextThingy.enabled = false;
        }
    }
}
