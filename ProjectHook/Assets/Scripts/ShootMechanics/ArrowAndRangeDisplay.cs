using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAndRangeDisplay : MonoBehaviour 
{
    [SerializeField] private GameObject arrowSprite;
    //[SerializeField] private GameObject rangeSprite;

    public void DisplayArrowAndRange()
    {
        arrowSprite.SetActive(true);
        //rangeSprite.SetActive(true);
    }

    public void HideArrowAndRange()
    {
        arrowSprite.SetActive(false);
        //rangeSprite.SetActive(false);
    }
}
