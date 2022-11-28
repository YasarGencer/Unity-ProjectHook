using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BloomColor", menuName = "Shop/BloomColor", order = 0)]
public class BloomColor : ScriptableObject
{
    public List<ItemBloomColor> bloomColor;
}
[System.Serializable]
public class ItemBloomColor: Content{
    [SerializeField] private Color color;
    [SerializeField] private float intensity;

    public Color Color { get { return color; } }
    public float Intensity { get { return intensity; } }
    public override void Buy() {
        if(GetBought() == 0) {
            if(CoinManager.GetCoins() >= Price) {
                SetBought();
            }
        }
    }
    public override int GetBought() {
        return PlayerPrefs.GetInt(PlayerPref.GetItemBloomColorIsBought(this.ID), 0);
    }
    public override void SetBought() {
        MainMenu.Instance.SetCoins();
        PlayerPrefs.SetInt(PlayerPref.GetItemBloomColorIsBought(this.ID), 1);
        IsBought= true;
    }
}
