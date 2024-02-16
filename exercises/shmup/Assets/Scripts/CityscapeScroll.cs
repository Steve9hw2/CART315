using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityscapeScroll : MonoBehaviour
{
    public float scrollSpeed;
    public float resetPos;
    public float setToPos;

    private float xPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xPos -= scrollSpeed;
        if (xPos <= resetPos)
        {
            xPos = setToPos;
        }
        transform.localPosition = new Vector3(xPos, -1, 0);
    }
}
