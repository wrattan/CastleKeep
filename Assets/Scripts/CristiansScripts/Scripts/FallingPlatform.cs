using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    //bool PlatformFalling = false;
    //float fallingSpeed = 0;
    

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Invoke("isPlatformFalling", 5);
        }
    }

    public void isPlatformFalling()
    {
        //PlatformFalling = true;
        //Destroy(gameObject, 3);
        gameObject.SetActive(false);
    }

    //void Update()
    //{
        //if(PlatformFalling)
        //{
            //fallingSpeed += Time.deltaTime / 170;

            //transform.position = new Vector3(transform.position.x, transform.position.y - fallingSpeed, transform.position.z);
        //}
    //}
}
