using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAndRangeDisplay : MonoBehaviour 
{
    [SerializeField] private GameObject arrowAndRange;

    public void DisplayArrowAndRange()
    {
        arrowAndRange.SetActive(true);
    }

    public void HideArrowAndRange()
    {
        arrowAndRange.SetActive(false);
    }
}
