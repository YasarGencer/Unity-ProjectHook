using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    [Tooltip("Camera's Speed in Y Axis"), SerializeField] float camSpeed = 1;
    [Tooltip("Max Value of The Camera's Speed in Y Axis"), SerializeField] float maxCamSpeed = 2f;
    [Tooltip("Multiplying Amount of The Multiplier"), SerializeField] float speedMultiplierAmount = 1.1f;
    [Tooltip("Timer in between Multiplications"), SerializeField] float speedMultiplierTimer = 20f;
    float currentMultiplier = 1;

    GameObject player;
    PlayerMovement playerMovement;
    private GameUIManager gameUIManager;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        StartCoroutine(Multiplier());
        StartCoroutine(StartSpeed(camSpeed));
        if(SceneManager.GetActiveScene().buildIndex != 0)
            gameUIManager = GameObject.Find("GameUIManager").GetComponent<GameUIManager>() as GameUIManager;
    }
    private void Update()
    {
        if (player & DeathManager.isDead != true)
            if (player.transform.position.y > this.transform.position.y){
                this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
                if(gameUIManager)
                    if(playerMovement.GetMoving())
                        gameUIManager.SetSetPostProcessing(true);
                    else
                        gameUIManager.SetSetPostProcessing(false);
                
            }
            else{                
                transform.Translate(Vector3.up * Time.deltaTime * camSpeed * currentMultiplier);
                if(gameUIManager)
                    gameUIManager.SetSetPostProcessing(false);
            }
        else{
            this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
            if(gameUIManager)
                    gameUIManager.SetSetPostProcessing(false);
        }
    }
    IEnumerator Multiplier()
    {
        currentMultiplier *= speedMultiplierAmount;
        yield return new WaitForSecondsRealtime(speedMultiplierTimer);
        if(camSpeed*currentMultiplier <= maxCamSpeed)
            StartCoroutine(Multiplier());
    }
    IEnumerator StartSpeed(float value)
    {
        camSpeed = 0;
        if(SceneManager.GetActiveScene().name != "Mainmenu")
            yield return new WaitForSeconds(2.5f);
        else
            yield return new WaitForSeconds(0);
        camSpeed = value;
    }
    public float GetSpeed()
    {
        return camSpeed;
    }
    public void SetSpeed(float speed)
    {
        camSpeed = speed;
    }
}
