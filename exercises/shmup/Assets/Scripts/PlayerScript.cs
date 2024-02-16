using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode shootKey;

    public GameObject bullet;
    public GameObject aimHelper;

    public float leftWall;
    public float rightWall;
    public float topWall;
    public float bottomWall;

    public float ascentSpeed;
    public float moveSpeed;
    public float descentSpeed;

    private float xPos = -7;
    private float yPos;

    private GameObject spawnedBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(leftKey) && xPos > leftWall){
            xPos -= moveSpeed;
        }
        if(Input.GetKey(rightKey) && xPos < rightWall){
            xPos += moveSpeed;
        }
        if(Input.GetKey(upKey) && yPos < topWall){
            yPos += ascentSpeed;
        }
        if(Input.GetKey(downKey) && yPos > bottomWall){
            yPos -= descentSpeed;
        }
        if(Input.GetKeyDown(shootKey)){
            fireBullet(xPos,yPos);
        }

        transform.localPosition = new Vector3(xPos, yPos, 0);

        aimHelper.transform.localPosition = transform.localPosition;
    }

    public void fireBullet(float xPos,float yPos) {
        spawnedBullet = Instantiate(bullet,new Vector3(xPos+1f,yPos,0),Quaternion.identity, this.transform);
        spawnedBullet.transform.parent = GameObject.Find("AimHelper").transform;
        spawnedBullet.transform.position = new Vector3(xPos+1f, yPos, 0);
    }

   

}
