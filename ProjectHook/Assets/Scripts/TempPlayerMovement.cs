using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMovement : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * Time.deltaTime * 3);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime);
    }
}
