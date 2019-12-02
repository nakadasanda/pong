using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManeger : MonoBehaviour
{
    public static SoundManeger Instance = null;

    public AudioClip gaolBloop;
    public AudioClip hitPaddleBloop;
    public AudioClip lossBuzz;
    public AudioClip winsound;
    public AudioClip wallBloop;

    private AudioSource SoundEffectAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource[] sources = GetComponents<AudioSource>();

        foreach (AudioSource source in sources)
        {
            if (source.clip == null)
            {
                SoundEffectAudio = source;
            }
        }
    }

    public void playOneShot(AudioClip clip)
    {
        SoundEffectAudio.PlayOneShot(clip);
    }
}
