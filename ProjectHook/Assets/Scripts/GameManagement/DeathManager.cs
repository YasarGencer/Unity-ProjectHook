using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private Transform playerTransform;
    private Transform cameraTransform;

    public static bool isDead = false;
    private void Start()
    {
        isDead = false;
        playerTransform = GameObject.Find("Player").transform;
        cameraTransform = GameObject.Find("Main Camera").transform;
    }
    void Update()
    {
        if (playerTransform.position.y < cameraTransform.position.y - 7f && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        CoinManager.AddCoiins((int)ScoreManager.score / 5);
        GameObject.Find("GameUIManager").GetComponent<GameUIManager>().Death();
    }
}
