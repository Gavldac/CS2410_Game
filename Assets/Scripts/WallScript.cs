using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class WallScript : MonoBehaviour
{
    public GameObject GameOver;
    public float size;
    private float min, max;
    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + size;
    }

    // Update is called once per frame
    void Update()
    {
        //Allows the enemy object to move only if the Game Over screen isn't visible.
        if (GameOver.activeSelf == false)
        {
            float pingpong = Mathf.PingPong(Time.time * 5, max - min) + min;
            Vector3 horizontal = new Vector3(pingpong, transform.position.y, transform.position.z);
            transform.position = horizontal;
        }
    }
}
