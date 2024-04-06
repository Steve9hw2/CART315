using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    private float timeTilEnd;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject sliderLab = GameObject.Find("Slider");
        timeTilEnd = sliderLab.GetComponent<Slider>().value;
        sliderLab.GetComponent<Slider>().value -= Time.deltaTime;
        if (timeTilEnd <= 0)
        {
            Application.Quit();
            Debug.Log("GAME OVER!");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("PLAYER LOCATED");
            Destroy(this);

        }
    }
}
