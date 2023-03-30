using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFloorDecoTrigGate : MonoBehaviour
{
    

    public GameObject moveGate;
    private float startLoc;
    private float endLoc;
    /*private bool isColliding;*/

    private void Start()
    {
        startLoc = moveGate.transform.position.y;
        endLoc = startLoc - 5;
        /*isColliding = false;*/
    }

    private void OnTriggerEnter()
    {
        /*isColliding = true;*/
        while (moveGate.transform.position.y > endLoc)
            moveGate.transform.position -= moveGate.transform.up * Time.deltaTime;
        
        

    }

    /*private void OnTriggerStay()
    {

        if (moveGate.transform.position.y > endLoc)
        {
            moveGate.transform.position -= moveGate.transform.up * Time.deltaTime;
        }
    }*/

    /*private void OnTriggerExit()
    {
        isColliding = false;
    }*/

    /*private void Update()
    {
        if (moveGate.transform.position.y < startLoc && isColliding == false)
        {
            moveGate.transform.position.y += moveGate.up * Time.deltaTime;
        }
            
    }*/




}
