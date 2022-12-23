using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GamePhases { AIM, SHOOT, HOOKMOVES, HOOKHITS, HOOKMISSES, PLAYERMOVES, PLAYERLOCATES }

    public static GamePhases currentGamePhase;

    private GameObject arrow;
    private GameObject hook;
    private GameObject player;

    private ArrowMovement arrowMovement;
    private HookMovement hookMovement;
    private PlayerMovement playerMovement;

    private ArrowAndRangeDisplay arrowAndRangeDisplay;
    private HookCollideDetector hookCollideDetector;

    private FreezeManager freezeManager;

    private Vector2 playerStartPosition;
    private void Start()
    {
        currentGamePhase = GamePhases.PLAYERLOCATES;
        arrow = GameObject.Find("Arrow");
        hook = GameObject.Find("Hook");
        player = GameObject.Find("Player");

        freezeManager = GetComponent<FreezeManager>();
        arrowMovement = arrow.GetComponent<ArrowMovement>();
        arrowAndRangeDisplay = GetComponent<ArrowAndRangeDisplay>();

        hookMovement = hook.GetComponent<HookMovement>();
        hookCollideDetector = hook.GetComponent<HookCollideDetector>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (DeathManager.isDead && freezeManager.GetFrozen() == false)
            return;
        if (freezeManager.GetFrozen() == true)
        {
            if (InputController.GetTouchPhase() == TouchPhase.Began)
            {
                if (PauseMenu.isPaused == false && Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position).y < 0.75)
                {
                    freezeManager.FrozenEffector();
                }
            }
            return;
        }
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
            arrowAndRangeDisplay.HideArrowAndRange();
            currentGamePhase = GamePhases.HOOKMOVES;
        }
        //--------------------------------------------------------------
        if (currentGamePhase == GamePhases.HOOKMOVES)
        {
            hookMovement.MoveFrom(player.transform);
            if (hookCollideDetector.GetPlatform() != null)
            {
                currentGamePhase = GamePhases.HOOKHITS;
                if (hookCollideDetector.GetPlatform().collider.CompareTag("Platform"))
                {
                    player.transform.parent = null;
                    hook.transform.parent = null;

                }
                if (hookCollideDetector.GetPlatform().collider.CompareTag("MovingPlatform"))
                {
                    player.transform.SetParent(hookCollideDetector.GetPlatform().collider.transform);
                    hook.transform.SetParent(hookCollideDetector.GetPlatform().collider.transform);
                }
            }
        }
        //--------------------------------------------------------------
        if (currentGamePhase == GamePhases.HOOKHITS)
        {

            currentGamePhase = GamePhases.PLAYERMOVES;
            playerStartPosition = player.transform.position;
            playerMovement.Invoke("StopMoving", playerMovement.moveDuration + 0.08f);
        }
        //--------------------------------------------------------------
        if (currentGamePhase == GamePhases.PLAYERMOVES)
        {
            //playerMovement.GoToPlatform(hookCollideDetector.GetPlatform().collider.gameObject, hook);
            playerMovement.MoveToPlatform(hookCollideDetector.GetPlatform().collider.gameObject,playerStartPosition, hook);
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
            hookMovement.SetPosition(player.transform);
            arrowAndRangeDisplay.DisplayArrowAndRange();
            currentGamePhase = GamePhases.AIM;
            hookCollideDetector.SetCurrentCollision(null);
        }
    }
}
