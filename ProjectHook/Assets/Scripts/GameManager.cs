using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool canThrowHook = true;
    private ArrowMovement arrowMovement;
    private ArrowAndRangeDisplay arrowAndRangeDisplay;

    private void Start()
    {
        arrowMovement = GameObject.Find("Arrow").GetComponent<ArrowMovement>();
        arrowAndRangeDisplay = GameObject.Find("GameManager").GetComponent<ArrowAndRangeDisplay>();
    }
    private void Update()
    {
        if (canThrowHook)
        {
            arrowAndRangeDisplay.DisplayArrowAndRange();
            arrowMovement.StartRotating();
        }
        else
        {
            arrowMovement.StopRotation();
            arrowAndRangeDisplay.HideArrowAndRange();
        }

    }
}
