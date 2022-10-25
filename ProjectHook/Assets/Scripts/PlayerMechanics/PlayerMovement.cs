using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject hook;

    private void Start()
    {
        hook = GameObject.Find("Hook");
    }
    public void GoToPlatform(GameObject platform)
    {
        var position = new Vector3(hook.transform.position.x, platform.transform.position.y + platform.transform.lossyScale.y / 2 + transform.lossyScale.y / 2, 0);
        transform.DOMove(position, 1f);
        Invoke("StopMoving", 1.5f);
    }

    private void StopMoving()
    {
        DOTween.Clear();
    }

}
