using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float bulletSpeed;
    public float deleteDist;
    public bool canMove;

    private float xPos;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.name == "Bullet(Clone)"){
            canMove = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
             if(xPos>=deleteDist){
            Destroy(this.gameObject);
            }
        xPos += bulletSpeed;
        transform.localPosition = new Vector3(xPos, transform.localPosition.y, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        Debug.Log("the bullet hit something!");
        if(other.gameObject.tag == "Enemy"){
            ScoreScript.S.UpdateScore();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
