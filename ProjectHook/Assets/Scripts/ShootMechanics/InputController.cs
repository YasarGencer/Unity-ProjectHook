using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController
{
    public static TouchPhase GetTouchPhase()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).phase;
        }
        return TouchPhase.Canceled;
    }
}
