using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    public GameObject death;
    [SerializeField] AudioSource musicSource;
    public AudioClip goobaStomp;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = goobaStomp;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(death.activeSelf == true)
        {
            musicSource.Stop();
        }
    }
}
