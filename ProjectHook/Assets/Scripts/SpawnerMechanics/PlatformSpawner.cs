using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    GameObject player;
    public /* static */PlatformManager platformManager; //static iken shop üzerinden deðer atanýp tema deðiþiklikliði yapýlabilir
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
        StartCoroutine(PlatformInstantiatorIEnum());
    }

    [Tooltip("Optimization Issues"), SerializeField] float inBetweenTime;
    [Tooltip("Y range of the platforms"), SerializeField] Vector2 verticalRange;
    [Tooltip("X range of the platforms"), SerializeField] Vector2 HorizontalRange;
    [Tooltip("Range in between player and spawner"), SerializeField] float range;
    IEnumerator PlatformInstantiatorIEnum()
    {
        if(range > this.transform.position.y - player.transform.position.y)
            PlatformInstantiator();
        yield return new WaitForSecondsRealtime(inBetweenTime);
        StartCoroutine(PlatformInstantiatorIEnum());
    }
    public void PlatformInstantiator()
    {
        Vector2 randomPos = this.transform.position;
        randomPos.x += Random.Range(HorizontalRange.x, HorizontalRange.y);
        Instantiate(platformManager.GetRandomPlatform().platform, randomPos, Quaternion.identity).name = "Instantiated-Platform";
        this.transform.position += Vector3.up * Random.Range(verticalRange.x, verticalRange.y);
    }
}
