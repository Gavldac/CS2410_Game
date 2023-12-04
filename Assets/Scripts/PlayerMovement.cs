using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{

    public Tilemap obstacles;
    public SpriteRenderer sprite;
    private Rigidbody2D player;
    [SerializeField] private float velocity;
    public Transform groundCheck, wallsCheck;
    public LayerMask groundLayer, wallsLayer;
    public GameObject GameOver;
    [SerializeField] private float speed;
    public static Vector3 firstPlayerPosition;
    private BoxCollider2D boxCollider;
    public float wallJumpCooldown;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        //get the RigidBody references from Unity Editor
        player = GetComponent<Rigidbody2D>(); 
        boxCollider = GetComponent<BoxCollider2D>();
        firstPlayerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Allows the player to move only if the Game Over screen isn't visible.
        if (GameOver.activeSelf == false)
        {
            //This is so we can track the player's velocity
            velocity = player.velocity.x;
            //Input.GetAxis() allows us to use the A or D keys for horizontal movement. 
            //Return value is -1 or 1 for left and right respectively. Needs a speed multiplier.
            

            if (wallJumpCooldown > 0.2f)
            {
                if (OnWall() && !IsGrounded())
                {
                    player.gravityScale = 1.5f;
                    player.velocity = Vector2.zero;
                }
                else
                {
                    horizontal = Input.GetAxisRaw("Horizontal");
                    player.velocity = new Vector2(horizontal * speed, player.velocity.y);
                    if (horizontal <= -1)
                    {
                        sprite.flipX = true;
                    }
                    else if (horizontal >= 1)
                    {
                        sprite.flipX = false;
                    }
                    player.gravityScale = 1.7f;
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    Jump();
                }
            }
            else
                wallJumpCooldown += Time.deltaTime;
            
        }
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            player.velocity = new Vector2(player.velocity.x, speed);
        }
        else if (OnWall() && !IsGrounded())
        {
            print(transform.localScale.x);
            player.velocity = new Vector2(-horizontal * 6, 6);
            wallJumpCooldown = 0;
            
        }
    }
    
    /// <summary>
    /// Creates a circle at player's feet. If it collides with the ground layer, then it will return true
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(horizontal, 0), 0.1f, wallsLayer);
        return raycastHit.collider != null;
    }
}
