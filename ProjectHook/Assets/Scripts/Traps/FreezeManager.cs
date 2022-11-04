using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeManager : MonoBehaviour
{
    private bool isFrozen = false;
    private int frozenTouchCount, unfrozeTouchCount = 2;
    [SerializeField] private GameObject[] iceLayers;
    [SerializeField] private GameObject particle;
    private Transform player;

    public static FreezeManager instance;
    private void Start() {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void SetFrozen(bool value){
        isFrozen = value;
    }
    public bool GetFrozen(){
        return isFrozen;
    }
    public void Freeze(){
        SetFrozen(true);
        foreach (var item in iceLayers){
            item.SetActive(true);
        }
    }
    public void UnFreeze(){
        SetFrozen(false);
        foreach (var item in iceLayers){
            item.SetActive(false);
        }
        frozenTouchCount = 0;
    }
    public void BreakIce(){
        iceLayers[frozenTouchCount].SetActive(false);
        IceParticle();
    }
    public void FrozenEffector(){
        if(frozenTouchCount>unfrozeTouchCount){
            UnFreeze();
            return;
        }
        else 
            BreakIce();
        frozenTouchCount++;
    }
    public void IceParticle(){
        Destroy(Instantiate(particle, player.position, Quaternion.identity),5f);
    }
}
