using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PvP_4x4 : XvX_Base
{
    private List<List<int>> win = new List<List<int>>()
    {
        new List<int>() { 0, 1, 2, 3 },
        new List<int>() { 4, 5, 6, 7 },
        new List<int>() { 8, 9, 10, 11 },
        new List<int>() { 12, 13, 14, 15 },
        

        new List<int>() { 0, 4, 8, 12 },
        new List<int>() { 1, 5, 9, 13 },
        new List<int>() { 2, 6, 10, 14 },
        new List<int>() { 3, 7, 11, 15 },

        new List<int>() { 0, 5, 10, 15 },
        new List<int>() { 3, 6, 9, 12 },
    };
    
    private void Start()
    {
        SetWin(win);
    }
}



