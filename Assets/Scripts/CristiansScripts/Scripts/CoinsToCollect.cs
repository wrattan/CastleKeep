using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsToCollect : MonoBehaviour
{
    public static int coins = -1;
    public static int key = 0;
    GameObject Obj;

    void Start()
    {
        Obj = GameObject.Find("ExitGate");
    }

    void Awake()
    {
        coins++;
    }

    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            coins--;
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(key == 1)
        {
            Obj.SetActive(false);
        }
    }
}
