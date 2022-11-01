using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Animator anim;
    Slider sfx, music;
    GameObject cam;
    float camSpeed = 0;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        this.GetComponent<Canvas>().worldCamera = cam.GetComponent<Camera>();
        anim = GetComponent<Animator>();

        Pause();
    }
    public void Pause()
    {
        camSpeed = cam.GetComponent<CameraMovement>().GetSpeed();
        cam.GetComponent<CameraMovement>().SetSpeed(0);

        //skor sayacý durdur
    }
    public void Unpause()
    {
        cam.GetComponent<CameraMovement>().SetSpeed(camSpeed);
    }
    public void Back()
    {
        anim.SetTrigger("Close");
        Destroy(this.gameObject, 3f);
        Invoke("Unpause", 2f);
    }
    public void Menu()
    {
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
