using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;
    public bool dead = false;
    public float time = 0f;
    public int score = 0;

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
       
        time += 10*Time.deltaTime ;
        score = (int)time;

        Debug.Log(score);

        if(dead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
            time = 0f;
        }

        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();

        float dirY = Input.GetAxis("Vertical");
        float dirJump = Input.GetAxis("Horizontal");

        isGround = Physics2D.OverlapCircle(groundCheckPoint.position , groundCheckRadius , groundLayer);
        
                // if(dirJump > 0f && isGround)
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
