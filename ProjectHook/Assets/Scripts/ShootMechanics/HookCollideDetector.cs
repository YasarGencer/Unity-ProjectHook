using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HookCollideDetector : MonoBehaviour
{
    public Collision2D currentCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            GameManager.currentGamePhase = GameManager.GamePhases.HOOKHITS;
            currentCollision = collision;
        }
    }
}
