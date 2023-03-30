using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CameraController : MonoBehaviour
{
    public GameObject KnightCamera;
    public GameObject WizardCamera;


    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            KnightCamera.SetActive(true);
            WizardCamera.SetActive(false);


        }
        else if (!PhotonNetwork.IsMasterClient)
        {
            KnightCamera.SetActive(false);
            WizardCamera.SetActive(true);

        }




    }
}