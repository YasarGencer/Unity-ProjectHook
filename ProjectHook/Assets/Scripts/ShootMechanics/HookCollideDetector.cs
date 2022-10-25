using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HookCollideDetector : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private HookMovement hookMovement;

    private void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        hookMovement = GetComponent<HookMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            GameManager.hookCanMove = false;
            GameManager.canThrowHook = true;

            playerMovement.GoToPlatform(collision.collider.gameObject);

            //hookMovement.ResetPosition();  // Normalde karakter platformun üstüne çýktýðýnda bu iþlem gerçekleþek
        }
    }
}
