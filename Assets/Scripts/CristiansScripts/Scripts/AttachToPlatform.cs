using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour
{
    public GameObject PlayerController;
    
    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerController.transform.parent = transform;
        }
    }
    
    public void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerController.transform.parent = null;
        }
    }
}
