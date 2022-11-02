using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private Transform playerTransform;
    private Transform originTransform;
    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        originTransform = GameObject.Find("OriginPoint").transform;
    }
    void Update()
    {
        if (Vector3.Distance(playerTransform.position, originTransform.position) > 10f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Ölüm menüsü açýlacak
        Debug.Log("Die");
    }
}
