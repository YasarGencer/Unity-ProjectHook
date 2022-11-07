using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject hook;

    [SerializeField] private GameObject arrow;
    [SerializeField] public float moveDuration = 0.8f;


    private void Start()
    {
        hook = GameObject.Find("Hook");
    }
    public void GoToPlatform(GameObject platform)
    {
        var position = new Vector3(hook.transform.position.x, platform.transform.position.y + 0.45f, 0);
        transform.DOMove(position, moveDuration);
    }
    public void StopMoving()
    {
        DOTween.Kill(transform);
        GameManager.currentGamePhase = GameManager.GamePhases.PLAYERLOCATES;
    }
    public void SetActiveArrow(bool value)
    {
        arrow.SetActive(value);
    }
}
