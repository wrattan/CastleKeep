using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    GameObject keyObj;
    GameObject chestObj;
    private int count = 1;

    void Start()
    {
        keyObj = GameObject.Find("Key");
        keyObj.SetActive(false);
        chestObj = GameObject.Find("ChestTop");
    }

    void Update()
    {
        if(count == 1)
        {
            if(CoinsToCollect.coins == 0)
            {
                keyObj.SetActive(true);
                chestObj.SetActive(false);
                count--;
            }
        }
    }
}
