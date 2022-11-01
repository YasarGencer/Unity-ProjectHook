using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static string highscoreT = "highScore";
    public static float score = 0;
    public static float scoreMultiplier = 5;

    private float targetScore = 0;
    [SerializeField] Transform playerTransform;
    
    private float startHeight;
    private float maxHeight = -10;
    
    [SerializeField] TextMeshProUGUI scoreText;
    private void Start()
    {
        InvokeRepeating("UpdateDisplayedScore", 0, 0.05f);
        playerTransform = GameObject.Find("Player").transform;
        startHeight = playerTransform.position.y;
    }
    private void Update()
    {
        UpdateTargetScore();
    }
    void UpdateTargetScore()
    {
        if(maxHeight < playerTransform.position.y)
            maxHeight = playerTransform.position.y;
        targetScore = (maxHeight - startHeight) * scoreMultiplier;
    }

    private void UpdateDisplayedScore()
    {
        if(score < targetScore)
            score++;
        scoreText.text = ((int)score).ToString();
    }
}
