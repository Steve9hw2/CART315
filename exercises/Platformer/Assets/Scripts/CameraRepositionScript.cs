using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRepositionScript : MonoBehaviour
{
    public Camera playerCam;
    public Camera camToFocus;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("PLAYER LOCATED");
            playerCam.transform.position = camToFocus.transform.position;
            playerCam.transform.rotation = camToFocus.transform.rotation;
        }
    }
}
