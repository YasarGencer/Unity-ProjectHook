using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GamePhases { AIM, SHOOT, HOOKMOVES, HOOKHITS, HOOKMISSES, PLAYERMOVES, PLAYERLOCATES }

    public static GamePhases currentGamePhase;

    private GameObject arrow;
    private GameObject hook;
    private ArrowMovement arrowMovement;
    private HookMovement hookMovement;
    private PlayerMovement playerMovement;

    private ArrowDirection arrowDirection;
    private ArrowAndRangeDisplay arrowAndRangeDisplay;
    private HookCollideDetector hookCollideDetector;

    private Vector3 direction;
    private Transform hookSpriteTransform;

    private void Start()
    {
        currentGamePhase = GamePhases.PLAYERLOCATES;
        arrow = GameObject.Find("Arrow");
        hook = GameObject.Find("Hook");

        arrowMovement = arrow.GetComponent<ArrowMovement>();
        hookMovement = hook.GetComponent<HookMovement>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        arrowDirection = GetComponent<ArrowDirection>();
        hookCollideDetector = hook.GetComponent<HookCollideDetector>();
        arrowAndRangeDisplay = GetComponent<ArrowAndRangeDisplay>();

        hookSpriteTransform = GameObject.Find("HookSprite").transform;
    }

    private void Update()
    {
        if(DeathManager.isDead == false){
        if (currentGamePhase == GamePhases.AIM)
        {
            hookSpriteTransform.rotation = arrow.transform.rotation;
            if (InputController.GetTouchPhase() == TouchPhase.Began || InputController.GetTouchPhase() == TouchPhase.Stationary)
            {
                if (PauseMenu.isPaused == false && Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position).y < 0.75)
                {
                    currentGamePhase = GamePhases.SHOOT;
                    direction = arrowDirection.GetArrowDirection();
                }
            }
        }

        if (currentGamePhase == GamePhases.SHOOT)
        {
            arrowMovement.StopRotation();
            currentGamePhase = GamePhases.HOOKMOVES;
        }

        if (currentGamePhase == GamePhases.HOOKMOVES)
        {
            arrowAndRangeDisplay.HideArrowAndRange();
            hookMovement.Move(direction);
        }

        if (currentGamePhase == GamePhases.HOOKHITS)
        {
            playerMovement.GoToPlatform(hookCollideDetector.currentCollision.collider.gameObject);
            currentGamePhase = GamePhases.PLAYERMOVES;
        }

        if (currentGamePhase == GamePhases.PLAYERMOVES)
        {

        }

        if(currentGamePhase == GamePhases.HOOKMISSES)
        {
            currentGamePhase = GamePhases.PLAYERLOCATES;
        }
        if (currentGamePhase == GamePhases.PLAYERLOCATES)
        {
            hookMovement.ResetPosition();
            arrowMovement.ResetArrowRotation();
            arrowAndRangeDisplay.DisplayArrowAndRange();
            arrowMovement.StartRotation();
            currentGamePhase = GamePhases.AIM;
        }
        }
    }
}
