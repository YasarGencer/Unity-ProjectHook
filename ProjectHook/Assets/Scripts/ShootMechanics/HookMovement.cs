using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    private ArrowDirection arrowDirection;
    private bool canMove = false;
    void Start()
    {
        arrowDirection = GameObject.Find("GameManager").GetComponent<ArrowDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputController.GetTouchPhase() == TouchPhase.Began || InputController.GetTouchPhase() == TouchPhase.Stationary)
            canMove = true;
        if (canMove)
        {
            transform.Translate(arrowDirection.GetArrowDirection() * Time.deltaTime * 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
            canMove = false;
    }
}
