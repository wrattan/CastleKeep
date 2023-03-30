using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOnTrigger : MonoBehaviour
{

    public GameObject movePlatform;
    private bool isColliding = false;

    private void OnTriggerEnter(Collider col)
    {
        isColliding = true;
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.parent = transform;
        }

    }

    private void OnTriggerStay(Collider col)
    {

        if (movePlatform.transform.position.y < 12)
            movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime * 4;
    }

    private void OnTriggerExit(Collider col)
    {
        isColliding = false;
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.parent = null;

        }
    }

    private void Update()
    {
        if (movePlatform.transform.position.y > 1 && isColliding == false)
            movePlatform.transform.position -= movePlatform.transform.up * Time.deltaTime * 4;
    }



}

