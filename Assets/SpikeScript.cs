using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour
{
    public GameObject player, GameOver, Health1, Health2, Health3;
    int health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            health = 0;
            player.SetActive(false);
            GameOver.SetActive(true);
        }
        if(health == 0)
        {
            Health1.SetActive(false);
            Health2.SetActive(false);
            Health3.SetActive(false);
        }
    }
    
}
