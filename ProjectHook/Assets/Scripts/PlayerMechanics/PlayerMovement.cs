//using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float moveDuration;
    float elapsedTime = 0;

    /*public void GoToPlatform(GameObject platform, GameObject hook)
    {
        var position = new Vector3(hook.transform.position.x, platform.transform.position.y + 0.45f, 0);
        transform.DOMove(position, moveDuration);
    }*/
    public void StopMoving()
    {
        //DOTween.Kill(transform);
        elapsedTime = 0;
        GameManager.currentGamePhase = GameManager.GamePhases.PLAYERLOCATES;
    }

    public void MoveToPlatform(GameObject platform,Vector2 startPos ,GameObject hook)
    {
        Vector2 targetPosition = new Vector3(hook.transform.position.x, platform.transform.position.y + 0.45f);
        transform.position = Vector2.Lerp(startPos, targetPosition, OutSine(elapsedTime / moveDuration)); 
        elapsedTime += Time.deltaTime;
    }
    private float OutSine(float t)
    {
        return Mathf.Sin((t * Mathf.PI) / 2); ;
    }
}
