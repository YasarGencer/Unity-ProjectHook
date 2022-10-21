using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirection : MonoBehaviour
{
    [SerializeField] private Transform arrowHead, arrowTail;

    public Vector3 GetArrowDirection()
    {
        var direction = arrowHead.position - arrowTail.position;
        return direction;
    }
}
