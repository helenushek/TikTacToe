using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static int size;
    public static GameState Gamestate;
    public static WhoisWon Whoiswon;
}

public enum GameState
{
    PvP,
    PvR,
    RvR
}

public enum WhoisWon
{
    Nobody,
    X,
    O
}