using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLayerManager : MonoBehaviour
{

    public GameObject brickhighest;
    public GameObject brickhigh;
    public GameObject brickmidhigh;
    public GameObject brickmidlow;
    public GameObject bricklow;
    public GameObject bricklowest;

    public float topleftX;
    public float topleftY;
    public float xSpacing;
    public int brickColumns;
    // Start is called before the first frame update
    void Start()
    {
        ResetBricks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBricks(){
        for(int i = 0; i < brickColumns; i = i+1){
            float xPos;
            xPos = topleftX + (i * xSpacing);
            Instantiate(brickhighest, new Vector3(xPos,topleftY,0),Quaternion.identity, this.transform);
             Instantiate(brickhigh, new Vector3(xPos,topleftY-0.5f,0),Quaternion.identity, this.transform);
            Instantiate(brickmidhigh, new Vector3(xPos,topleftY-1f,0),Quaternion.identity, this.transform);
            Instantiate(brickmidlow, new Vector3(xPos,topleftY-1.5f,0),Quaternion.identity, this.transform);
            Instantiate(bricklow, new Vector3(xPos,topleftY-2f,0),Quaternion.identity, this.transform);
            Instantiate(bricklowest, new Vector3(xPos,topleftY-2.5f,0),Quaternion.identity, this.transform);
        }
    }
}
