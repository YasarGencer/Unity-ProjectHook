using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject pause, pauseButton;
    [SerializeField] GameObject death;
    [SerializeField] Volume postProcessing;
    [SerializeField] GameObject[] lights;
    
    [HideInInspector] public bool setPostProcessing;

    private void Awake() {
        PauseMenu.isPaused = false;
    }
    private void Start()
    {
        pauseButton.SetActive(false);
        Invoke("PauseButton",3);
        if (PlayerPrefs.GetInt("Graphics", 1) == 0)
        {
            postProcessing.gameObject.SetActive(false);
            foreach (var item in lights)
            {
                if (item.name == "GlobalLight")
                    item.GetComponent<Light2D>().intensity = 1;
                else
                    item.SetActive(false);
            }
        }
    }
    void Update(){
        SetPostProcessing(setPostProcessing);
    }
    public void Pause()
    {
        Instantiate(pause);
    }
    public void PauseButton(){
        pauseButton.SetActive(true);
    }
    public void Death(){
        Instantiate(death);
    }
    public void SetPostProcessing(bool value){
        if(PlayerPrefs.GetInt("Graphics", 1) == 1){
            if (postProcessing.profile.TryGet<ChromaticAberration>(out var chromaticAberration)){
                if (value == true){
                    chromaticAberration.intensity.value += .05f;
                }
                else{
                    chromaticAberration.intensity.value -= .05f;
                }
                chromaticAberration.intensity.value =  Mathf.Clamp(chromaticAberration.intensity.value, .3f, .75f);
            }            

        }        
    }
    public void SetSetPostProcessing(bool value){
        setPostProcessing = value;
    }
}
