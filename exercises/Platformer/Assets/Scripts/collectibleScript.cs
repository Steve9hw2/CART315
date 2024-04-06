using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class collectibleScript : MonoBehaviour
{
    float x;
    float y;
    float z;

    public GameObject gameManager;
    public GameObject slider;
    public float collectibleTimeVal;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationSpeed * Time.deltaTime,0f, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        slider.GetComponent<Slider>().value += collectibleTimeVal;
        Destroy(gameObject);
    }

}
