using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    public static bool playOnce;
    public GameObject death;
    [SerializeField] AudioSource musicSource, deathSource;
    public AudioClip goobaStomp, deathSound;
    // Start is called before the first frame update
    void Start()
    {
        playOnce = true;
        musicSource.clip = goobaStomp;
        deathSource.clip = deathSound;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(death.activeSelf == true)
        {
            musicSource.Stop();
            if(playOnce == true)
            {
                deathSource.Play();
                playOnce = false;
            }
        }
    }
}
