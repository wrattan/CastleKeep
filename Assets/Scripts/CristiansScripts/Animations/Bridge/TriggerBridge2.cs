using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBridge2 : MonoBehaviour
{

    [SerializeField] private Animator animator;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        animator.SetBool("LowerBridge2", true);
    }

    //void OnCollisionExit(Collision collision)
    //{
        //if (collision.gameObject.tag == "Player") 
        //animator.SetBool("LowerBridge1", false);
    //}

}
