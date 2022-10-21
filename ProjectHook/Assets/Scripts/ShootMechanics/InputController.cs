using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static int currentPhase = 0;
    public static int isReleased;
    void Update()
    {
        Debug.Log(currentPhase);
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) // Ekrana týklama
                currentPhase = 1;
            if (touch.phase == TouchPhase.Stationary) // Týklama ama hareket ettirmeme
                currentPhase = 2;
            if(touch.phase == TouchPhase.Ended) // Ekrandan kaldýrma
                currentPhase = 0;
        }
    }
}
