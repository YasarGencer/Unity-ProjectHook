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
        SceneManager.LoadScene("GameScene");
    }
}
