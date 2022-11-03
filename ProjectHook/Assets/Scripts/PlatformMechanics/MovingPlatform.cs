using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    Vector2 startPos;
    Vector2 endPos;
    [SerializeField] float speed = 1;
    private void Start()
    {
        startPos = new Vector3(-1.5f, transform.position.y,0);
        endPos = new Vector3(1.5f, transform.position.y,0);
        transform.position = startPos;

        transform.DOMove(endPos, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
    
}
