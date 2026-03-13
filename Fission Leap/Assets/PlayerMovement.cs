using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Threading;
public class PlayerMovement : MonoBehaviour
{
    public Vector3 playerPosition;
    public Rigidbody2D rb;
    [SerializeField]
    private float jumpForce;
    public bool touchingFloor;
    [SerializeField]
    public float walkSpeed;
    private bool jumping;
    [SerializeField]
    public GameObject SpawnPoint;
    public int health;
    public int maxHealth;
    public int score;
    public static Scene currentScene;
    public GameObject gameOverCanvas;
    public int maxJump;
    public int jumps;
    public UIbehaviour UIbehaviour;
    public bool climbing;
    public float climbSpeed = 3;
    public bool touchingClimable;
    public bool lookingRight;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false);
        jumpForce = 300;
        walkSpeed = 10.5f;
        maxHealth = 3;
        transform.position = SpawnPoint.transform.position;
        health = maxHealth;
        maxJump = 1;
        rb.gravityScale = 1;
        climbSpeed = 5;
        touchingClimable = false;
        anim = GetComponent<Animator>();
        anim.SetBool("LookingRight", true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        if (touchingClimable == true && Input.GetKeyDown(KeyCode.F))
        {
            climbing = true;
        }
        playerPosition = transform.position;
        playerPosition.z = -1;
        if (Input.GetAxis("Horizontal") > 0)
        {
            playerPosition.x += walkSpeed * Time.deltaTime;
            transform.position = playerPosition;
            anim.SetBool("MovingRight", true);
            anim.SetBool("MovingLeft", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("LookingRight", true);

        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            playerPosition.x -= walkSpeed * Time.deltaTime;
            transform.position = playerPosition;
            anim.SetBool("MovingLeft", true);
            anim.SetBool("MovingRight", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("LookingRight", false);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("MovingRight", false);
            anim.SetBool("MovingLeft", false);
            anim.SetBool("IsIdle", true);
        }
        if (climbing == true)
        {
            jumping = false;
        }
        if (climbing == true)
        {
            rb.gravityScale = 0.4f;
        }
        else
        {
            rb.gravityScale = 1;
        }
        if (touchingClimable == false)
        {
            climbing = false;
        }
        if (climbing == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (jumps < maxJump && jumping == false && rb.velocity.y <= 3)
                {
                    jumping = true;
                }
                else
                {
                    jumping = false;
                }
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (climbing == true)
            {
                playerPosition.y += climbSpeed * Time.deltaTime;
                transform.position = playerPosition;
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        } else if (Input.GetKey(KeyCode.T))
        {
            if (climbing == true)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }

        }

        if (score < 0)
        {
            score = 0;
        }
        if (health <= 0 )
        {
            gameOverCanvas.SetActive(true);
            score = 0;
            health = maxHealth;
        }
        rb.velocity = new Vector2(0, rb.velocity.y);

        //testing keybinds (get rid of for actual release)
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            health = 0;
        }
        if (Input.GetKeyDown(KeyCode.Tilde))
        {
            UIbehaviour.nextLevel();
        }
    }

    private void FixedUpdate()
    {
        if (jumping == true)
        {
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            //Debug.Log ("Jumped");
            jumping = false;
            jumps += 1;
        }
        //if (touchingFloor = true)
        //{
        //    jumps = 0;
        //}
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            touchingFloor = true;
            jumps = 0;
            anim.SetBool("IsFalling", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            touchingFloor = false;
            anim.SetBool("IsFalling", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Kill box")
        {
            transform.position = SpawnPoint.transform.position;
            health += -1;
        }
        if (collision.gameObject.tag == "1 point giver")
        {
            score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Next Level")
        {
            UIbehaviour.nextLevel();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Climable surface")
        {

            touchingClimable = true;
            Debug.Log("Can climb");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Climable surface")
        {
            touchingClimable = false;
            Debug.Log("Can't climb anymore");
        }
    }
    private void DirectionRight()
    {
        anim.SetBool("LookingRight", true);
    }
    private void DirectionLeft()
    {
        anim.SetBool("LookingRight", false);
    }

}
