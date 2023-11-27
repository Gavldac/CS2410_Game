using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject GameOver, Health1, Health2, Health3;
    public static int health = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Allows the enemy object to move only if the Game Over screen isn't visible.
        if (GameOver.activeSelf == false)
        {
            Vector3 horizontal = new Vector3(Mathf.PingPong(Time.time * 4, 8), transform.position.y, transform.position.z);
            transform.position = horizontal;
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
            }
        }
    }
}
