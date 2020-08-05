using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;

    /** Ground Check **/
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isGround;

    /** Animation **/
    private Animator playerAnimation;

    /** Duck **/
    private bool isDuck;


    private Rigidbody2D rb ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = new Vector2(speed,rb.velocity.y);

        float dirY = Input.GetAxis("Vertical");

        isGround = Physics2D.OverlapCircle(groundCheckPoint.position , groundCheckRadius , groundLayer);
        if(Input.GetButtonDown("Jump") && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
            Debug.Log(rb.velocity);
            Debug.Log("Jumping");
        }

        if(dirY < 0f)
        {
            isDuck = true;
        }
        else
        {
            isDuck = false;
        }

        /** Animation **/
        playerAnimation.SetBool("jump",!isGround);
        playerAnimation.SetBool("isDuck",isDuck);
    }

    
}
