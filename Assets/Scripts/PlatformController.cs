using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformController : MonoBehaviour
{
    [HideInInspector] public bool jump = true;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public float moveSpeed;
    public Transform groundCheck;
    public Text scoreText;
    public static int test = 1;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    private float playTime;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        playTime = 0;
        //SetScore();
    }

    // Update is called once per frame
    void Update()
    {
     
        LayerMask ground = LayerMask.GetMask("Ground");
        grounded = rb2d.IsTouchingLayers(ground);

        //Debug to check if grounded returns what it should
        //Debug.Log(grounded);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;

        }

        playTime += Time.deltaTime;
        //SetScore();
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        //float moveV = Input.GetAxis("Vertical");
        //Vector2 movement = new Vector2(moveH,moveV);
        //rb2d.AddForce(movement * moveSpeed);

        if (moveH * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * moveH * moveForce);
        }
        
        if(Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        if (jump)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    //void SetScore()
    //{
    //    int cTime = (int)Mathf.Floor(playTime);
    //    scoreText.text = "Time: " + cTime.ToString();
    //}
}
