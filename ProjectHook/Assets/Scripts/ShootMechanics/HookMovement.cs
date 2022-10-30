using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    private Transform playerTransform;
    private Transform arrowTransform;
    private Transform hookSpriteTransform;
    
    private ArrowDirection arrowDirection;
    private Vector3 direction;
    
    [SerializeField] private float hookSpeed = 2f;
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        arrowDirection = GameObject.Find("GameManager").GetComponent<ArrowDirection>();
        arrowTransform = GameObject.Find("Arrow").transform;
        hookSpriteTransform = GameObject.Find("HookSprite").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.hookCanMove)
            Move();
        else
            hookSpriteTransform.rotation = arrowTransform.rotation;

        if ((InputController.GetTouchPhase() == TouchPhase.Began || InputController.GetTouchPhase() == TouchPhase.Stationary) && GameManager.canThrowHook)
        {
            GameManager.hookCanMove = true;
            GameManager.canThrowHook = false;
            direction = arrowDirection.GetArrowDirection();
        }
    }
    private void Move()
    {
        transform.Translate(direction * Time.deltaTime * hookSpeed);
    }
    
    public void ResetPosition()
    {
        transform.position = playerTransform.position;
    }
}
