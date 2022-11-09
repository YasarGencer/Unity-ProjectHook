using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject player;
    public /* static */ PlatformManager platformManager; //static iken shop �zerinden de�er atan�p tema de�i�iklikli�i yap�labilir
    [SerializeField] Transform spawnParent;
    enum SpawnType
    {
        PLATFORM,
        DETAIL
    }
    [SerializeField] SpawnType spawnType;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(InstantiatorIEnum());
    }

    [Tooltip("Optimization Issues"), SerializeField] float inBetweenTime;
    [Tooltip("Y range of the platforms"), SerializeField] Vector2 verticalRange;
    [Tooltip("X range of the platforms"), SerializeField] Vector2 HorizontalRange;
    [Tooltip("Range in between player and spawner"), SerializeField] float range;
    IEnumerator InstantiatorIEnum()
    {
        if (range > this.transform.position.y - player.transform.position.y)
            Instantiator();
        yield return new WaitForSecondsRealtime(inBetweenTime);
        StartCoroutine(InstantiatorIEnum());
    }
    public void Instantiator()
    {
        Vector2 randomPos = this.transform.position;
        randomPos.x += Random.Range(HorizontalRange.x, HorizontalRange.y);
        GameObject spawned = null;
        if (spawnType == SpawnType.PLATFORM)
        {
            if(ScoreManager.score > 100)
                spawned = Instantiate(platformManager.GetRandom(platformManager.GetPlatformList()), randomPos, Quaternion.identity);
            else
                spawned = Instantiate(platformManager.GetRandom(platformManager.GetBasicPlatformList()), randomPos, Quaternion.identity);
            spawned.name = "Instantiated-Platform";
        }
        else if (spawnType == SpawnType.DETAIL)
        {
            spawned = Instantiate(platformManager.GetRandom(platformManager.GetDetailsList()), randomPos, Quaternion.identity);
            spawned.name = "Instantiated-Detail";
        }
        spawned.transform.SetParent(spawnParent);
        this.transform.position += Vector3.up * Random.Range(verticalRange.x, verticalRange.y);
    }
}
