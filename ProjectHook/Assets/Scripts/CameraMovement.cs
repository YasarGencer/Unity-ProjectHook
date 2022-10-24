using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Tooltip("Camera's Speed in Y Axis"), SerializeField] float camSpeed = 1;
    [Tooltip("Multiplying Amount of The Multiplier"), SerializeField] float speedMultiplierAmount = 1.1f;
    [Tooltip("Timer in between Multiplications"), SerializeField] float speedMultiplierTimer = 10f;
    float currentMultiplier;

    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentMultiplier = 1 / speedMultiplierAmount;
        StartCoroutine(Multiplier());
    }
    private void Update()
    {
        if (player.transform.position.y > this.transform.position.y)
            this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
        else
            transform.Translate(Vector3.up * Time.deltaTime * camSpeed * currentMultiplier);
    }
    IEnumerator Multiplier()
    {
        currentMultiplier *= speedMultiplierAmount;
        yield return new WaitForSecondsRealtime(speedMultiplierTimer);
        StartCoroutine(Multiplier());
    }
}
