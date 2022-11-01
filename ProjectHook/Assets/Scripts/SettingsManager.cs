using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] GameObject postProcessing;
    [SerializeField] GameObject[] lights;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Graphics", 0) == 0)
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
}
