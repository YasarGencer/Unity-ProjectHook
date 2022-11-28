using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    public static string GetItemBloorColor() {
        return "Item-BloorColor";
    }
    public static string GetItemBloomColorIsBought(int id) {
        return "Item-BloomColor-" + id + "-isBought";
    }
    public static string GetCoins() {
        return "Player-Coins";
    }
}
