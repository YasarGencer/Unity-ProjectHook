using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject pause, pauseButton;
    [SerializeField] GameObject postProcessing;
    [SerializeField] GameObject[] lights;
    
    private void Awake() {
        PauseMenu.isPaused = false;
    }
    private void Start()
    {
        pauseButton.SetActive(false);
        Invoke("PauseButton",3);
        if (PlayerPrefs.GetInt("Graphics", 1) == 0)
        {
            postProcessing.SetActive(false);
            foreach (var item in lights)
            {
                if (item.name == "GlobalLight")
                    item.GetComponent<Light2D>().intensity = 1;
                else
                    item.SetActive(false);
            }
        }
    }
    public void Pause()
    {
        Instantiate(pause);
    }
    public void PauseButton(){
        pauseButton.SetActive(true);
    }
}
