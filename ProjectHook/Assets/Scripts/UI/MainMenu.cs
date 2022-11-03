using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    Animator gameAnimator;

    public TextMeshProUGUI highMark, lowMark;
    public Slider music, sfx;
    public GameObject postProcessing;

    static string  rateUsURL = "https://play.google.com/store/apps/dev?id=8567089145193331467",
    playStoreURL = "https://play.google.com/store/apps/dev?id=8567089145193331467",
    yasarURL = "https://www.linkedin.com/in/yasargencer/",
    altayURL = "https://www.linkedin.com/in/altayturan/",
    blackspirestudioURL = "https://blackspirestudio.itch.io/medieval-pixel-art-asset-free",
    tinyworldsURL = "https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059";

    string[] id = {rateUsURL, playStoreURL, yasarURL, altayURL, blackspirestudioURL, tinyworldsURL};

    private void Start()
    {
        gameAnimator = GetComponentInParent<Animator>() as Animator;
        GetSelectedGraphics(); 
        GetAudio();
    }

    public void StartButton()
    {
        gameAnimator.SetTrigger("StartGame");
        Invoke("LoadScene", 3.5f);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SettingsOpen()
    {
        gameAnimator.SetTrigger("SettOpen");
    }
    public void SettingsClose()
    {
        gameAnimator.SetTrigger("SettClose");
    }
    public void InfoOpen()
    {
        gameAnimator.SetTrigger("InfoOpen");
    }
    public void InfoClose()
    {
        gameAnimator.SetTrigger("InfoClose");
    }

    public void GetSelectedGraphics()
    {
        if (PlayerPrefs.GetInt("Graphics", 1) == 0)
            SelectLowGraphics();
        else
            SelectHighGraphics();
    }
    public void SelectLowGraphics()
    {
        PlayerPrefs.SetInt("Graphics", 0);
        highMark.text = "";
        lowMark.text = "x";
        postProcessing.SetActive(false);
    }
    public void SelectHighGraphics()
    {
        PlayerPrefs.SetInt("Graphics", 1);
        highMark.text = "x";
        lowMark.text = "";
        postProcessing.SetActive(true);
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
    public void OpenUrl(int id){
        Application.OpenURL(this.id[id]);
    }
}
