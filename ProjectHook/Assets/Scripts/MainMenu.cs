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
        if (PlayerPrefs.GetInt("Graphics", 0) == 0)
            SelectLowGraphics();
        else
            SelectHighGraphics();
    }
    public void SelectLowGraphics()
    {
        PlayerPrefs.SetInt("Graphics", 0);
        highMark.text = "";
        lowMark.text = "x";
    }
    public void SelectHighGraphics()
    {
        PlayerPrefs.SetInt("Graphics", 1);
        highMark.text = "x";
        lowMark.text = "";
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
