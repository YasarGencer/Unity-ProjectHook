using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    Animator anim;
    [SerializeField] Slider sfx, music;
    CameraMovement cam;
    float camSpeed = 0, scoreMultiplier;
    public static bool isPaused = false;
    [SerializeField] TextMeshProUGUI hscoreText;
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        this.GetComponent<Canvas>().worldCamera = cam.gameObject.GetComponent<Camera>();
        anim = GetComponent<Animator>();
        Pause();
    }
    public void Pause()
    {
        //PAUSE
        camSpeed = cam.GetSpeed();
        cam.SetSpeed(0);

        scoreMultiplier = ScoreManager.scoreMultiplier;
        ScoreManager.scoreMultiplier = 0;

        //SET VALUES
        isPaused = true;
        ScoreManager.SetHigscore();
        hscoreText.text = ScoreManager.GetHighscore().ToString();

        GetAudio();
    }
    public void Unpause()
    {
        cam.SetSpeed(camSpeed);
        ScoreManager.scoreMultiplier = scoreMultiplier;
        isPaused = false;
    }
    public void Back()
    {
        anim.SetTrigger("Close");
        Destroy(this.gameObject, 3f);
        Invoke("Unpause", 2f);
    }
    public void Menu()
    {
        ScoreManager.scoreMultiplier = scoreMultiplier;
        SceneManager.LoadScene("Mainmenu");
    }
    public void GetAudio()
    {
        music.value = PlayerPrefs.GetFloat("music", 0.5f);
        sfx.value = PlayerPrefs.GetFloat("sfx", 0.5f);
    }
    public void SetMusic()
    {
        PlayerPrefs.SetFloat("music", music.value);
    }
    public void SetSFX()
    {
        PlayerPrefs.SetFloat("sfx", sfx.value);
    }
}
