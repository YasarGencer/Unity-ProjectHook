using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    private Transform playerTransform;
    
    [SerializeField] private float hookSpeed = 2f;
    private float range = 6f;
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * hookSpeed);
        if (Vector3.Distance(playerTransform.position, transform.position) > range)
            GameManager.currentGamePhase = GameManager.GamePhases.HOOKMISSES;
    }
    
    public void ResetPosition()
    {
        transform.position = playerTransform.position;
    }
}
