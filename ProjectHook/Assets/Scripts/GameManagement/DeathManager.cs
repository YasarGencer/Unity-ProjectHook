using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private Transform playerTransform;
    private Transform cameraTransform;

    private bool isDead = false;
    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        cameraTransform = GameObject.Find("Main Camera").transform;
    }
    void Update()
    {
        if (playerTransform.position.y < cameraTransform.position.y - 6f && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Die");
        isDead = true;
    }
}
