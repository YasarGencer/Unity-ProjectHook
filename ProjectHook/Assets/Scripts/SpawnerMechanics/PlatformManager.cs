using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Platform List", menuName = "PlatformList")]
public class PlatformManager : ScriptableObject
{
    [SerializeField] List<GameObject> platformList;
    [SerializeField] List<GameObject> detailsList;
    public GameObject GetRandom(List<GameObject> list) { return list[Random.Range(0, list.Count)]; }

    public List<GameObject> GetPlatformList() { return platformList; }
    public List<GameObject> GetDetailsList() { return detailsList; }
}
