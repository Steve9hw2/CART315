using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;

    public static ScoreScript S;

    void Awake() {
        S = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore() {
        score += 100;
        string scoreDisplay = score.ToString();
        scoreText.text = scoreDisplay;
    }

}
