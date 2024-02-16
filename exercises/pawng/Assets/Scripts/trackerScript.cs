using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackerScript : MonoBehaviour
{
    public GameObject sleepy;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(sleepy, new Vector3(0,0,0),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
