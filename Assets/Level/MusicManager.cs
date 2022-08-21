using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioClip endMusic, finalMusic, phase1Music, phase2Music, phase3Music, startMidMusic, startFinalMusic;
    public AudioSource audioSrc;
    private float audioVolume = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = audioVolume;
    }

    public void SetVolume(float vol)
    {
        audioVolume = vol;
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "end":
                audioSrc.Stop();
                audioSrc.PlayOneShot(endMusic);
                audioSrc.PlayScheduled(AudioSettings.dspTime + endMusic.length);
                break;
            case "final":
                audioSrc.Stop();
                audioSrc.PlayOneShot(finalMusic);
                audioSrc.PlayScheduled(AudioSettings.dspTime + finalMusic.length);
                break;
            case "phase1":
                audioSrc.Stop();
                audioSrc.PlayOneShot(phase1Music);
                audioSrc.PlayScheduled(AudioSettings.dspTime + phase1Music.length);
                break;
            case "phase2":
                audioSrc.Stop();
                audioSrc.PlayOneShot(phase2Music);
                audioSrc.PlayScheduled(AudioSettings.dspTime + phase2Music.length);
                break;
            case "phase3":
                audioSrc.Stop();
                audioSrc.PlayOneShot(phase3Music);
                audioSrc.PlayScheduled(AudioSettings.dspTime + phase3Music.length);
                break;
            case "start":
                audioSrc.Stop();
                audioSrc.PlayOneShot(startMidMusic);
                audioSrc.PlayScheduled(AudioSettings.dspTime + startMidMusic.length);
                break;
            case "startFinal":
                audioSrc.Stop();
                
                audioSrc.PlayOneShot(startFinalMusic);
                audioSrc.PlayScheduled(AudioSettings.dspTime + startFinalMusic.length);
                break;
        }
    }
}