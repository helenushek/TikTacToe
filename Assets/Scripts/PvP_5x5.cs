using System.Collections.Generic;

public class PvP5X5 : PvPBase
{
    private List<List<int>> _win = new List<List<int>>()
    {
        new List<int>() { 0, 1, 2, 3, 4 },
        new List<int>() { 5, 6, 7, 8, 9 },
        new List<int>() { 10, 11, 12, 13, 14 },
        new List<int>() { 15, 16, 17, 18, 19 },
        new List<int>() { 20, 21, 22, 23, 24 },

        new List<int>() { 0, 5, 10, 15, 20 },
        new List<int>() { 1, 6, 11, 16, 21 },
        new List<int>() { 2, 7, 12, 17, 22 },
        new List<int>() { 3, 8, 12, 18, 23 },
        new List<int>() { 4, 9, 14, 19, 24 },

        new List<int>() { 0, 6, 12, 18, 24 },
        new List<int>() { 4, 8, 12, 16, 20 },
    };
    private void Start()
    {
        SetWin(_win);
    }
}