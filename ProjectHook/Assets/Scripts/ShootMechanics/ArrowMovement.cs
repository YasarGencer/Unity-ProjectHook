using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowMovement : MonoBehaviour
{
    void Start()
    {
        RotateArrow();
    }

    private void Update()
    {
        if(InputController.currentPhase == 1 || InputController.currentPhase == 2)
            StopRotatingArrow();
    }

    public void RotateArrow()
    {
        // Sonsuz �al��mas� i�in tek sefer �al��t�r�lmal�.
        var tween = gameObject.transform.DORotate(new Vector3(0, 0, -45f), 1f).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);

    }

    public void StopRotatingArrow()
    {
        DOTween.Clear();
    }

}
