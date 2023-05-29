using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PvP_3x3 : XvX_Base
{
    private List<List<int>> win = new List<List<int>>()
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
        SetWin(win);
    }
}

public enum FirstPlayer
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