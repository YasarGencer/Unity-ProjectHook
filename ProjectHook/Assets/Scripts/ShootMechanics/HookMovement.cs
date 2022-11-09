using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{

    [SerializeField] private float hookSpeed = 2f;
    [SerializeField] private float range = 6f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    public void MoveFrom(Transform from)
    {
        transform.Translate(Vector2.up * Time.deltaTime * hookSpeed);
        if (Vector3.Distance(from.position, transform.position) > range)
            GameManager.currentGamePhase = GameManager.GamePhases.HOOKMISSES;
    }

    public void SetPosition(Transform target)
    {
        transform.position = target.position;
    }

    public void RotateWith(Transform target)
    {
        transform.rotation = target.rotation;
    }

    public void StopHook()
    {
        Debug.Log("Girdi");
    }
}
