using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    public Tilemap obstacles;
    public SpriteRenderer sprite;
    private Rigidbody2D player;
    [SerializeField] private float velocity;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject GameOver;
    [SerializeField] private float speed;
    public int amountJump = 0;


    // Start is called before the first frame update
    void Start()
    {
        //get the RigidBody references from Unity Editor
        player = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {

        //This is so we can track the player's velocity
        velocity = player.velocity.x;
        //Input.GetAxis() allows us to use the A or D keys for horizontal movement. 
        //Return value is -1 or 1 for left and right respectively. Needs a speed multiplier.
        float horizontal = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(horizontal * speed, player.velocity.y);
        
        if(horizontal <= -1)
        {
            sprite.flipX = true;
        }
        else if(horizontal >= 1)
        {
            sprite.flipX = false;
        }
        //Jump key checker
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
            player.velocity = new Vector2(player.velocity.x, speed);
        //Allows the player to move only if the Game Over screen isn't visible.
        if (GameOver.activeSelf == false)
        {
            //Input.GetAxis() allows us to use the A or D keys for horizontal movement. 
            //Return value is -1 or 1 for left and right respectively. Needs a speed multiplier.
            player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y);

            //Jump key and amount of jumps checker
            if (Input.GetKey(KeyCode.Space) && amountJump < 2)
            {
                amountJump++;
                player.velocity = new Vector2(player.velocity.x, speed);
            }
        }
    }

    /// <summary>
    /// Used to check collisions and reverts the amount of jumps back to zero.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            amountJump = 0;
            Debug.Log("Enter");
            Debug.Log(amountJump);
        }
    }
    
    /// <summary>
    /// Creates a circle at player's feet. If it collides with the ground layer, then it will return true
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

}
