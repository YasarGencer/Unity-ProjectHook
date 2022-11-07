using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float moveDuration = 0.8f;


    public void GoToPlatform(GameObject platform, GameObject hook)
    {
        var position = new Vector3(hook.transform.position.x, platform.transform.position.y + 0.45f, 0);
        transform.DOMove(position, moveDuration);
    }
    public void StopMoving()
    {
        DOTween.Kill(transform);
        GameManager.currentGamePhase = GameManager.GamePhases.PLAYERLOCATES;
    }
}
