using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownOnCollistion : MonoBehaviour
{

    public GameObject movePlatform;

    private void OnTriggerStay()
    {
        movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime;
    }
    


    
}
