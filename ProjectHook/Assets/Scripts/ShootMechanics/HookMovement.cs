using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    private Transform playerTransform;
    private ArrowDirection arrowDirection;

    private Vector3 direction;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        arrowDirection = GameObject.Find("GameManager").GetComponent<ArrowDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.hookCanMove)
        {
            Move();
        }
        if ((InputController.GetTouchPhase() == TouchPhase.Began || InputController.GetTouchPhase() == TouchPhase.Stationary) && GameManager.canThrowHook)
        {
            GameManager.hookCanMove = true;
            GameManager.canThrowHook = false;
            direction = arrowDirection.GetArrowDirection();
        }
    }
    private void Move()
    {
        transform.Translate(direction * Time.deltaTime * 2f);
    }
    
    public void ResetPosition()
    {
        transform.position = playerTransform.position;
    }
}
