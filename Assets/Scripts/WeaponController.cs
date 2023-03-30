using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Breakable"))
        {
            if(player.GetComponent<PlayerController>().isAttacking)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
