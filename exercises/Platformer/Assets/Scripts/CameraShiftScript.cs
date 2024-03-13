using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShiftScript : MonoBehaviour
{
    public Camera camToStop;
    public Camera camToFocus;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("PLAYER LOCATED");
            camToStop.enabled = false;
            camToFocus.enabled = true;
        }
    }
}
