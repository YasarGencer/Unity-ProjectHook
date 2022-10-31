using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    private Transform playerTransform;
    
    [SerializeField] private float hookSpeed = 2f;
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * hookSpeed);
    }
    
    public void ResetPosition()
    {
        transform.position = playerTransform.position;
    }
}
