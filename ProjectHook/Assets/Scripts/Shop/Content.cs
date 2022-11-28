using UnityEngine;

public abstract class Content 
{
    public int ID;
    public string Name;
    public float Price;
    public bool IsBought;

    public abstract void Buy();
    public void Equip() {
        Debug.Log("equip");
    }
    public abstract int GetBought();
    public abstract void SetBought();
}
