using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource Pleer;
    [SerializeField] AudioClip Musics;
    [SerializeField] private float Volume;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Pleer.PlayOneShot(Musics);
    }

    public void StopMusic()
    {
        Pleer.volume = 0;
    }

    public void ContinueMusic()
    {
        Pleer.volume = Volume;
    }
}
