using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelKey : MonoBehaviour
{
    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            CoinsToCollect.key++;
            gameObject.SetActive(false);
        }
    }
}
