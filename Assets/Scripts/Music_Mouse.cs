using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Mouse : MonoBehaviour

{
    [SerializeField] AudioSource PleerMouse;
    [SerializeField] AudioClip MusicsMouse;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PleerMouse.PlayOneShot(MusicsMouse);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}