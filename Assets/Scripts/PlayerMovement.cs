using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D player;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        //get the RigidBody references from Unity Editor
        player = GetComponent<Rigidbody2D>(); 

    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis() allows us to use the A or D keys for horizontal movement. 
        //Return value is -1 or 1 for left and right respectively. Needs a speed multiplier.
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y);

        //Jump key checker
        if (Input.GetKey(KeyCode.Space))
            player.velocity = new Vector2(player.velocity.x, speed);
    }
}
