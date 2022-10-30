using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowMovement : MonoBehaviour
{
    private bool isRotating = false;
    [SerializeField] private float maxDegree = 45f;
    [SerializeField] private float rotationDuration = 2f;

    private void Update()
    {
        if (GameManager.canThrowHook)
        {
            StartRotation();
        }
        else
            if(isRotating)
                StopRotation();
    }
    private void RotateArrow()
    {
        gameObject.transform.DORotate(new Vector3(0, 0, -maxDegree), rotationDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    public void StartRotation()
    {
        if (!isRotating)
        {
            RotateArrow();
            isRotating = true;
        }
    }
    private void ResetArrowRotation()
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, maxDegree));
    }

    public void StopRotation()
    {
        DOTween.Clear();
        Debug.Log("RotationKilled");

        Invoke("ResetArrowRotation", 0.99f);
        isRotating = false;
    }

}
