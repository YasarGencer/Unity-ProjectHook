using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject hook;
    private HookMovement hookMovement;

    [SerializeField] private float moveDuration = 1f;

    private void Start()
    {
        hook = GameObject.Find("Hook");
        hookMovement = hook.GetComponent<HookMovement>();

    }
    public void GoToPlatform(GameObject platform)
    {
        var position = new Vector3(hook.transform.position.x, platform.transform.position.y + platform.transform.lossyScale.y / 2 + transform.lossyScale.y / 2, 0);
        GameManager.isPlayerMoving = true;
        transform.DOMove(position, moveDuration);
        Invoke("StopMoving", moveDuration + .2f);
    }

    private void StopMoving()
    {
        DOTween.Clear();
        Debug.Log("MovingKilled");
        GameManager.isPlayerMoving = false;
        GameManager.canThrowHook = true;
        hookMovement.ResetPosition();
    }

}