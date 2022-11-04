using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GamePhases { AIM, SHOOT, HOOKMOVES, HOOKHITS, HOOKMISSES, PLAYERMOVES, PLAYERLOCATES }

    public static GamePhases currentGamePhase;

    private GameObject arrow;

    private ArrowMovement arrowMovement;
    private HookMovement hookMovement;
    private PlayerMovement playerMovement;

    private ArrowAndRangeDisplay arrowAndRangeDisplay;
    private HookCollideDetector hookCollideDetector;

    private FreezeManager freezeManager;

    private void Start()
    {
        currentGamePhase = GamePhases.PLAYERLOCATES;
        arrow = GameObject.Find("Arrow");

        freezeManager = GetComponent<FreezeManager>();
        arrowMovement = GameObject.Find("Arrow").GetComponent<ArrowMovement>();
        arrowAndRangeDisplay = GetComponent<ArrowAndRangeDisplay>();

        hookMovement = GameObject.Find("Hook").GetComponent<HookMovement>();
        hookCollideDetector = GameObject.Find("Hook").GetComponent<HookCollideDetector>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (DeathManager.isDead == false && freezeManager.GetFrozen() == false)
        {
            //--------------------------------------------------------------
            if (currentGamePhase == GamePhases.AIM)
            {
                hookMovement.RotateWith(arrow.transform);
                if (InputController.GetTouchPhase() == TouchPhase.Began || InputController.GetTouchPhase() == TouchPhase.Stationary)
                {
                    if (PauseMenu.isPaused == false && Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position).y < 0.75)
                    {
                        currentGamePhase = GamePhases.SHOOT;
                    }
                }
            }
            //--------------------------------------------------------------
            if (currentGamePhase == GamePhases.SHOOT)
            {
                arrowMovement.StopRotation();
                currentGamePhase = GamePhases.HOOKMOVES;
            }
            //--------------------------------------------------------------
            if (currentGamePhase == GamePhases.HOOKMOVES)
            {
                arrowAndRangeDisplay.HideArrowAndRange();
                hookMovement.Move();
            }
            //--------------------------------------------------------------
            if (currentGamePhase == GamePhases.HOOKHITS)
            {
                currentGamePhase = GamePhases.PLAYERMOVES;
                playerMovement.Invoke("StopMoving", playerMovement.moveDuration +0.1f);
            }
            //--------------------------------------------------------------
            if (currentGamePhase == GamePhases.PLAYERMOVES)
            {
                playerMovement.GoToPlatform(hookCollideDetector.currentCollision.collider.gameObject);
                
            }
            //--------------------------------------------------------------
            if (currentGamePhase == GamePhases.HOOKMISSES)
            {
                currentGamePhase = GamePhases.PLAYERLOCATES;
            }
            //--------------------------------------------------------------
            if (currentGamePhase == GamePhases.PLAYERLOCATES)
            {
                arrowMovement.ResetArrowRotation();
                arrowMovement.StartRotation();

                hookMovement.ResetPosition();
                arrowAndRangeDisplay.DisplayArrowAndRange();

                currentGamePhase = GamePhases.AIM;
            }
        }
        else if (freezeManager.GetFrozen() == true)
        {
            if (InputController.GetTouchPhase() == TouchPhase.Began)
            {
                if (PauseMenu.isPaused == false && Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position).y < 0.75)
                {
                    freezeManager.FrozenEffector();
                }
            }
        }
    }
}
