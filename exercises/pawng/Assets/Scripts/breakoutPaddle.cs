using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class breakoutPaddle : MonoBehaviour
{
    private float xPos;
    public float paddleSpeed = .05f;
    public float leftWall, rightWall;

    public Sprite originalImg;
    public Sprite replacedImg;

    public KeyCode leftKey, rightKey;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Paddle";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey))
        {
            if (xPos > leftWall)
            {
                xPos -= paddleSpeed;
            }
        }
        if (Input.GetKey(rightKey))
        {
            if (xPos < rightWall)
            {
                xPos += paddleSpeed;
            }
        }

        transform.localPosition = new Vector3(xPos, transform.position.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // repx = other.transform.localPosition.x;
        // repy = other.transform.localPosition.y;
        // Destroy(other.gameObject);
        //Instantiate(replacement, new Vector3(repx, repy, 0),Quaternion.identity);
        // replacement.gameObject.GetComponent<ballScript>().ballSpeed = 4f;
        // replacement.gameObject.GetComponent<ballScript>().Launch();
        other.gameObject.GetComponent<SpriteRenderer>().sprite = replacedImg;
    }
}
