using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject hook;
    private HookMovement hookMovement;
    private ArrowMovement arrowMovement;

    [SerializeField] private float moveDuration = 1f;

    private void Start()
    {
        hook = GameObject.Find("Hook");
        arrowMovement = GameObject.Find("Arrow").GetComponent<ArrowMovement>();
        hookMovement = hook.GetComponent<HookMovement>();

    }
    public void GoToPlatform(GameObject platform)
    {
        var position = new Vector3(hook.transform.position.x, platform.transform.position.y + 0.45f , 0);
        transform.DOMove(position, moveDuration);
        Invoke("StopMoving", moveDuration + .2f);
    }

    private void StopMoving()
    {
        DOTween.Clear();
        Debug.Log("MovingKilled");
        hookMovement.ResetPosition();
        arrowMovement.ResetArrowRotation();
        GameManager.currentGamePhase = GameManager.GamePhases.PLAYERLOCATES;
        ScoreManager.ScoreBonus();
    }

}
