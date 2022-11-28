using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    static int coins;
    public static int Coins { get => coins; }

    public static void SetCoins(int value) {
        PlayerPrefs.SetInt(PlayerPref.GetCoins(), value);
    }
    public static void AddCoiins(int value) {
        PlayerPrefs.SetInt(PlayerPref.GetCoins(), GetCoins() + value);
    }
    public static int GetCoins() {
        return PlayerPrefs.GetInt(PlayerPref.GetCoins(), 0);
    }
}
