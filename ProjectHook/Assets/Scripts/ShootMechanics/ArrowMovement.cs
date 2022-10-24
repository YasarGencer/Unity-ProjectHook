using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowMovement : MonoBehaviour
{
    private bool isRotating = false;
    private void RotateArrow()
    {
        // Sonsuz çalýþmasý için tek sefer çalýþtýrýlmalý.
        var tween = gameObject.transform.DORotate(new Vector3(0, 0, -45f), 2f).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
    }

    public void StartRotating()
    {
        if (!isRotating)
        {
            RotateArrow();
            isRotating = true;
        }
    }
    private void ResetArrowRotation()
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
    }

    public void StopRotation()
    {
        DOTween.Clear();
        Invoke("ResetArrowRotation", 0.1f);
        isRotating = false;
    }

}
