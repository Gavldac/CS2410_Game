using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject GameOver, Player, Health1, Health2, Health3;
    Transform PlayerMove;
    public Button Retry;

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
        GameOver.SetActive(false);
        Enemy.health = 3;
        Health1.SetActive(true);
        Health2.SetActive(true);
        Health3.SetActive(true);
        PlayerMove = Player.GetComponent<Transform>();
        PlayerMove.position = new Vector3(-7.41f, -2.31f, 0.0f);
    }
}