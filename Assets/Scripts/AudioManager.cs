using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource platformSound;
    private AudioSource brickSound;
    private AudioSource loseSound;
    private AudioSource lifeSound;
    private AudioSource laserSound;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        platformSound = audioSources[0];
        brickSound = audioSources[1];
        loseSound = audioSources[2];
        lifeSound = audioSources[3];
        laserSound = audioSources[4];
    }

    public void PlaySound(string sound)
    {
        switch (sound)
        {
            case "platformSound":
                platformSound.Play();
                break;
            case "brickSound":
                brickSound.Play();
                break;
            case "loseSound":
                loseSound.Play();
                break;
            case "lifeSound":
                lifeSound.Play();
                break;
            case "laserSound" :
                laserSound.Play();
                break;
                
        }
    }
}
