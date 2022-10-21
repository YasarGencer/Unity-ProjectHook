using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    private ArrowDirection arrowDirection;
    private Rigidbody2D rb;
    void Start()
    {
        arrowDirection = GameObject.Find("GameManager").GetComponent<ArrowDirection>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InputController.currentPhase == 3)
        {
            Debug.Log("Girdi");
            rb.AddForce(arrowDirection.GetArrowDirection());
        }
    }
}
