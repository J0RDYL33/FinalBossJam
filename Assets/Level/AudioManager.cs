using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip bossBullet, cultistFlame, dash, doubleJump, jump, playerDamage, rewindTime, swordSwing, foot1, foot2, foot3, foot4, foot5, foot6;
    public AudioSource audioSrc;
    public AudioSource walkingSrc;
    private float audioVolume;
    // Start is called before the first frame update
    void Start()
    {
        audioVolume = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = audioVolume;
        walkingSrc.volume = audioVolume / 4;
    }

    public void SetVolume(float vol)
    {
        audioVolume = vol;
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "bossBullet":
                audioSrc.PlayOneShot(bossBullet);
                break;
            case "cultistFlame":
                audioSrc.PlayOneShot(cultistFlame);
                break;
            case "dash":
                audioSrc.PlayOneShot(dash);
                break;
            case "doubleJump":
                audioSrc.PlayOneShot(doubleJump);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "playerDamage":
                audioSrc.PlayOneShot(playerDamage);
                break;
            case "rewindTime":
                audioSrc.PlayOneShot(rewindTime);
                break;
            case "swordSwing":
                audioSrc.PlayOneShot(swordSwing);
                break;
            case "foot1":
                walkingSrc.PlayOneShot(foot1);
                break;
            case "foot2":
                walkingSrc.PlayOneShot(foot2);
                break;
            case "foot3":
                walkingSrc.PlayOneShot(foot3);
                break;
            case "foot4":
                walkingSrc.PlayOneShot(foot4);
                break;
            case "foot5":
                walkingSrc.PlayOneShot(foot5);
                break;
            case "foot6":
                walkingSrc.PlayOneShot(foot6);
                break;
        }
    }
}
