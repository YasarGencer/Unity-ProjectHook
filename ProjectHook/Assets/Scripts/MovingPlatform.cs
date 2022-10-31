using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Vector2 startPos;
    int dir = 1;
    [SerializeField] float speed = 1;
    [SerializeField] float range = 1;
    private void Start()
    {
        startPos = this.transform.position;
    }
    void Update()
    {
        transform.Translate(Vector2.right * dir * Time.deltaTime * speed);

        if (this.transform.position.x > startPos.x + range)
            dir = -1;
        else if (this.transform.position.x < startPos.x - range)
            dir = 1;
    }
}
