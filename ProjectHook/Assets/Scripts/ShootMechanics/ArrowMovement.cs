using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class ArrowMovement : MonoBehaviour
{
    void Start()
    {
        RotateArrow();
    }

    public void RotateArrow()
    {
        // Sonsuz çalýþmasý için tek sefer çalýþtýrýlmalý.
        var tween = gameObject.transform.DORotate(new Vector3(0, 0, -45f), 1f).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
        if(Input.GetKeyDown(KeyCode.W))
            tween.Kill();
    }

}
