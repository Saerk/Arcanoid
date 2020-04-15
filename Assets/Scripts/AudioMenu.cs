using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    public new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        audio.Play();
    }
}
