using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Platform List", menuName = "PlatformList")]
public class PlatformManager : ScriptableObject
{
    [SerializeField] List<GameObject> basicPlatformList, advancedPlatformList;
    [SerializeField] List<GameObject> detailsList;
    List<GameObject> allPlatformList = new List<GameObject>();

    private void SetAllPlatforms() {
        foreach (GameObject item in basicPlatformList)
            allPlatformList.Add(item);
        foreach (GameObject item in advancedPlatformList)
            allPlatformList.Add(item);
        Debug.Log(allPlatformList.Count);
    }
    public GameObject GetRandom(List<GameObject> list){ return list[Random.Range(0, list.Count)]; }
    public List<GameObject> GetPlatformList() { if(allPlatformList.Count <= 0) SetAllPlatforms(); return allPlatformList; }
    public List<GameObject> GetBasicPlatformList() { return basicPlatformList; }
    public List<GameObject> GetDetailsList() { return detailsList; }
}
