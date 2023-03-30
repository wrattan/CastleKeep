using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    void Update()
    {
        if (this.gameObject.tag == "Door")
            if (obj == null)
                this.transform.rotation = Quaternion.Euler(0, -90, 0);  
    }
}
