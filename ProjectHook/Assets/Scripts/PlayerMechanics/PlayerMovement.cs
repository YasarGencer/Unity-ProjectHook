using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject platform;
    private bool canMove = false;
    public void GoToPlatform()
    {
        var position = new Vector3(transform.position.x, platform.transform.position.y + platform.transform.lossyScale.y / 2 + player.transform.lossyScale.y / 2, 0);
        transform.DOMove(position, 1f);
    }

    public void Move()
    {
        if (canMove)
        {
            GoToPlatform();
            canMove = false;
            Invoke("StopMoving", 1f);
        }
    }

    private void StopMoving()
    {
        DOTween.Clear();
        canMove = true;
    }

}
