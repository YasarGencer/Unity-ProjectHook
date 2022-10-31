using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Animator gameAnimator;

    private void Start()
    {
        gameAnimator = GetComponentInParent<Animator>() as Animator;
    }

    public void StartButton()
    {
        gameAnimator.SetTrigger("StartGame");
        Invoke("LoadScene", 3f);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("YasarScene");
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
}
