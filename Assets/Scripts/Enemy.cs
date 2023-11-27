using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject GameOver, Health1, Health2, Health3, Player;
    public SpriteRenderer sprite;
    public static int health = 3;
    public float min;
    public float max;
    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Allows the enemy object to move only if the Game Over screen isn't visible.
        if (GameOver.activeSelf == false)
        {
            float pingpong = Mathf.PingPong(Time.time * 2, max - min) + min;
            Vector3 horizontal = new Vector3(pingpong, transform.position.y, transform.position.z);
            transform.position = horizontal;
            if (pingpong <= 23.55)
            {
                sprite.flipX = false;
            }
            else if (pingpong >= 28.5)
            {
                sprite.flipX = true;
            }
        }
    }
    /// <summary>
    /// Controls the health of the player and decides when the game is over.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            health -= 1;
            if (health == 2)
            {
                Health3.SetActive(false);
            }
            if (health == 1)
            {
                Health2.SetActive(false);
            }
            if (health == 0)
            {
                Health1.SetActive(false);
                GameOver.SetActive(true);
                Player.SetActive(false);
            }
        }
    }
}
