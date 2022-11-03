using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] private float maxDegree = 45f;
    [SerializeField] private float rotationDuration = 2f;

    public void StartRotation()
    {
        gameObject.transform.DORotate(new Vector3(0, 0, -maxDegree), rotationDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    public void ResetArrowRotation()
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, maxDegree));
    }

    public void StopRotation()
    {
        DOTween.Kill(transform);
    }

}
