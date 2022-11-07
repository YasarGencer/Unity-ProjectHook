using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameManager;

public class HookCollideDetector : MonoBehaviour
{
    private Collision2D currentCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentCollision = collision;
    }


    public void SetCurrentCollision(Collision2D value)
    {
        currentCollision = value;
    }

    public Collision2D GetPlatform()
    {
        if (currentCollision == null)
            return null;
        if (currentCollision.collider.CompareTag("Platform") || currentCollision.collider.CompareTag("MovingPlatform"))
            return currentCollision;
        return null;
    }
}
