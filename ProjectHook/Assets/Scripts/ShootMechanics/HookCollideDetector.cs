using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HookCollideDetector : MonoBehaviour
{
    public Collision2D currentCollision;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.CompareTag("Platform"))
        {
            playerTransform.transform.parent = null;
            this.transform.parent = null;
            GameManager.currentGamePhase = GameManager.GamePhases.HOOKHITS;
            currentCollision = collision;
        }
        if (collision.collider.CompareTag("MovingPlatform"))
        {
            playerTransform.SetParent(collision.collider.transform);
            this.transform.SetParent(collision.collider.transform);
            GameManager.currentGamePhase = GameManager.GamePhases.HOOKHITS;
            currentCollision = collision;
        }
    }
}
