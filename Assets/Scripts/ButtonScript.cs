using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject GameOver, player, Health1, Health2, Health3;
    Transform PlayerMove;
    public Button Retry;
    [SerializeField] AudioSource musicSource;
    public AudioClip goobaStomp;

    void Start()
    {
        //Adds an action listener to the retry button.
        Retry.onClick.AddListener(TaskOnClick);
    }

    /// <summary>
    /// Whenever the button is clicked it will reset everything.
    /// </summary>
    void TaskOnClick()
    {
        player.SetActive(true);
        GameOver.SetActive(false);
        Enemy.health = 3;
        Health1.SetActive(true);
        Health2.SetActive(true);
        Health3.SetActive(true);
        PlayerMove = player.GetComponent<Transform>();
        PlayerMove.position = Player.firstPlayerPosition;
        musicSource.clip = goobaStomp;
        musicSource.Play();
    }
}