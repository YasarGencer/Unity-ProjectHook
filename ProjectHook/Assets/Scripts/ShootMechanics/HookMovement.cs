using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    private ArrowDirection arrowDirection;
    private GameManager gameManager;
    private bool canMove = false;

    private Vector3 direction;

    void Start()
    {
        arrowDirection = GameObject.Find("GameManager").GetComponent<ArrowDirection>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
        if ((InputController.GetTouchPhase() == TouchPhase.Began || InputController.GetTouchPhase() == TouchPhase.Stationary) && gameManager.canThrowHook)
        {
            canMove = true;
            gameManager.canThrowHook = false;
            direction = arrowDirection.GetArrowDirection();
        }
    }
    private void Move()
    {
        transform.Translate(direction * Time.deltaTime * 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            canMove = false;
            gameManager.canThrowHook = true;
        }
    }
}
