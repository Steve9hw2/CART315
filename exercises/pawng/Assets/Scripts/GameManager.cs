using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public int brickCount;

    public static GameManager S;
   // public GameObject BrickLayerManager;

    public TMP_Text scoreLabel; 
    public TMP_Text livesLabel;

    // Start is called before the first frame update
    void Awake()
    {
        if(S){
            return;
        }else{
            S = this;
        }
    }

    void Start() {
        lives = 3;
        livesLabel.text = lives.ToString();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loseLife(){
        if(lives==1){
             SceneManager.LoadScene("breakoutGame");
        }else{
        lives -= 1;
        livesLabel.text = lives.ToString();
        }
    }

    public void gainScore(){
        score += 500;
        scoreLabel.text = score.ToString();
    }

    public void resetBrickCount(){
        brickCount = 72;
    }

    public void subtractBrickCount(){
        brickCount--;
        if(brickCount==0){
         //   BrickLayerManager.ResetBricks();
            resetBrickCount();
        }
    }
}
