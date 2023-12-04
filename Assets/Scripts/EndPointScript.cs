using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointScript : MonoBehaviour
{
    public GameObject player;
    public float x, y;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = new Vector2(x, y);
    }
}
