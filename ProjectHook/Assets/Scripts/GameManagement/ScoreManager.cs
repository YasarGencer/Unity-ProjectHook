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
    Transform playerTransform;
    
    private float startHeight;
    private float maxHeight = -10;
    
    [SerializeField] TextMeshProUGUI scoreText;
    Animator scoreAnim;
    private void Start()
    {
        score = -1;
        InvokeRepeating("UpdateDisplayedScore", 0, 0.05f);
        playerTransform = GameObject.Find("Player").transform;
        startHeight = playerTransform.position.y;
        scoreAnim = scoreText.gameObject.GetComponent<Animator>();
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
        if(score < targetScore){
            scoreAnim.SetBool("ScoreUp", true);
            score++;
        }
        else
            scoreAnim.SetBool("ScoreUp", false);
        scoreText.text = ((int)score).ToString();
    }

    public static void SetHigscore(){
        if(PlayerPrefs.GetInt(highscoreT,0) < score)
            PlayerPrefs.SetInt(highscoreT,(int)score);
    }
    public static int GetHighscore(){
        return PlayerPrefs.GetInt(highscoreT,0);
    }
}
