using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Platform List", menuName = "PlatformList")]
public class PlatformManager : ScriptableObject
{
    [SerializeField] List<Platform> platformList;
    Platform GetPlatform(int value)
    {
        if (platformList.Count <= value)
            return new Platform();
        else
            return platformList[value];
    }
    int GetRandomPlatformID() { return Random.Range(0, platformList.Count); } 
    //bu fonksiyon dýþardan çaðýrýlýr diðer fonksiyonlar bu fonksiyonun parametresizz çaðýrýlabilmesi için var
    public Platform GetRandomPlatform() { return GetPlatform(GetRandomPlatformID()); }
}

[System.Serializable]
public struct Platform
{
    public GameObject platform;
}
