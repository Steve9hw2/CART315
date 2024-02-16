using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public float enemyRange;
    public float topWall;
    public float bottomWall;

    private float topY;
    private float bottomY;

    private float xPos = 11;
    private float yPos = 20;

    private bool goingUp = false;
    private bool pathGenerated = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(yPos < 10) {
            if (!pathGenerated)
            {
                generatePath();
            }
            animateY();
            xPos -= xSpeed;
            if (xPos < -10)
            {
                Destroy(this.gameObject);
            }
            transform.localPosition = new Vector3(xPos, yPos, 0);
        }      
    }

    void generatePath()
    {
        if (yPos + enemyRange > topWall)
        {
            topY = topWall;
        }
        else
        {
            topY = yPos + enemyRange;
        }
        if (yPos - enemyRange < bottomWall)
        {
            bottomY = bottomWall;
        } 
        else
        {
            bottomY = yPos - enemyRange;
        }
        pathGenerated = true;
    }

    void animateY()
    {
        if (goingUp && yPos < topY)
        {
            yPos += ySpeed;
        } 
        if (goingUp && yPos >= topY)
        {
            goingUp = false;
        }
        if (!goingUp && yPos > bottomY)
        {
            yPos -= ySpeed;
        }
        if (!goingUp && yPos <= bottomY)
        {
            goingUp = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Scene");
        }
    }
}
