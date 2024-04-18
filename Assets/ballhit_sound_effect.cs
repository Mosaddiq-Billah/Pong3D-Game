using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ballhit_sound_effect : MonoBehaviour
{
    public AudioSource bounceClip; // Reference to the bounce sound clip

    private void Start()
    {
        // Make sure to assign the AudioClip in the Unity Editor to bounceClip.audioClip
        //bounceClip = GetComponent<AudioSource>();
    }

   
}
