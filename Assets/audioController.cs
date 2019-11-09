using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public Boss bossi;

    public AudioSource StartSound;
    public AudioSource EndSound;
    public AudioSource takeHit;
    public AudioSource FactorySound;
    public AudioSource GameMusic;
    public AudioSource tadaa;
    public AudioSource BossBreath;
    public AudioSource lever;

    bool doOnce = true;
    int hp = 3;
    int newHp;
    // Start is called before the first frame update
    void Start()
    {
        StartSound.volume = 0.1f;
        StartSound.Play();
        //GameMusic = GetComponent<AudioSource>();
    }

    public void playDeathSound()
    {
        //EndSound.Play();
        if (doOnce)
        {
            doOnce = false;
            AudioSource.PlayClipAtPoint(EndSound.clip, this.transform.position);
            GameMusic.Stop();
            Debug.Log("DEAD");
        }
    }
    public void takeHitSound()
    {
        AudioSource.PlayClipAtPoint(takeHit.clip, this.transform.position);
    }

    public void FactorySounds(bool play)
    {
        if (play)
        {
            FactorySound.volume = .6f;
            //AudioSource.PlayClipAtPoint(FactorySound.clip, this.transform.position);
        }
        else
        {
            FactorySound.volume = 0;
            //FactorySound.Stop();
        }
    }

    public void confused(bool yes)
    {
        if (yes)
        {
            Debug.Log("asdasd");
            GameMusic.pitch = -1f;
        }
        else
        {
            GameMusic.pitch = 1f;
        }
    }

    public void doTadaa()
    {
        tadaa.Play();
        //AudioSource.PlayClipAtPoint(tadaa.clip, this.transform.position);
    }

    public void Bosautus()
    {

        if (!BossBreath.isPlaying)
            BossBreath.Play();

        else
            BossBreath.Stop();
        //AudioSource.PlayClipAtPoint(BossBreath.clip, this.transform.position);
    }
    public void pullLever()
    {
        lever.Play();
    }
}
