using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCollisionTrig : MonoBehaviour
{
    [SerializeField] private GameObject door1, door2;

    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            
            door1.transform.rotation = Quaternion.Euler(0, -90, 0);
            door2.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
}
