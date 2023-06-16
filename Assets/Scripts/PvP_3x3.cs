using System.Collections.Generic;

public class PvP3X3 : PvPBase
{
    private List<List<int>> _win = new List<List<int>>()
    {
        new List<int>() { 0, 1, 2 },
        new List<int>() { 3, 4, 5 },
        new List<int>() { 6, 7, 8 },

        new List<int>() { 0, 3, 6 },
        new List<int>() { 1, 4, 7 },
        new List<int>() { 2, 5, 8 },

        new List<int>() { 0, 4, 8 },
        new List<int>() { 2, 4, 6 },
    };

    private void Start()
    {
        SetWin(_win);
    }
}

public enum WhoIsOn
{
    Cross,
    Circle,
}

public enum Turn
{
    None,
    Enemy,
    Player,
}