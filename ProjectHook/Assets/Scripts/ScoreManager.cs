using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static string highscoreT = "highScore";
    public static float score = 0;
    public static float scoreMultiplier = 1;
    
    [SerializeField] TextMeshProUGUI scoreText;
    private void Update()
    {
        UpdateScore();
    }
    void UpdateScore()
    {
        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = ((int)score).ToString();
    }
    public static void ScoreBonus()
    {
        score += Random.Range(15,45);
    }
}
