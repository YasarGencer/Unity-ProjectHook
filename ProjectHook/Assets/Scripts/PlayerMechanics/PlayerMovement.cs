using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject hook;
    private HookMovement hookMovement;
    private ArrowMovement arrowMovement;
    
    [SerializeField] private GameObject arrow;
    [SerializeField] private float moveDuration = 1f;


    private void Start()
    {
        hook = GameObject.Find("Hook");
        arrowMovement = GetComponentInChildren<ArrowMovement>();
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
        GameManager.currentGamePhase = GameManager.GamePhases.PLAYERLOCATES;
    }
    public void SetActiveArrow(bool value){
        arrow.SetActive(value);
    }

}
