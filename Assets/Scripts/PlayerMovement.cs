using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*  This script is the most important it's used to control the player's controls
*  and controlling their speed
*  
* Script: PlayerMovement
* @author  Greg Wang and Brian Grigore
* @version 1.0
* @since   2020-01-12
*/
public class PlayerMovement : MonoBehaviour
{
    //Takes in variables that need to be taken in such as the animator, the run speed
    //Horizontal/Vertical input and move speed etc.
    public Animator animator;
    public float runSpeed = 40f;
    public Time_Storage Current_Time;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float inputVertical;
    public float inputHorizontal;
    public float distance;
    public GameObject Tree;
    public GameObject Tree2;
    public GameObject Wheat;
    public GameObject WheatImage;
    public GameObject AppleImage;
    public LayerMask whatIsLadder;
    public bool isClimbing;
    Rigidbody2D rb;
    public float maxSpeed = 5f;
    public bool onLadder = false;
    public float verticalSpeed = 5;
    public bool m_FacingRight = true;
    public float distance_y;
    //These variables are generally used for checks such as what counts as apples or if the player has and apple
    public LayerMask whatIsApple;
    public LayerMask whatIsApple2;
    public LayerMask whatIsWheat;
    public bool hasApple;
    public bool hasApple2;
    public bool hasWheat;
    
    public AudioSource MusicSource; // sets refrences to the audio clips and the audio source
    public AudioClip walking;

    //Start function to initialize two variables
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasApple = false;
    }

       /**
       * Description: Checks the player's horizontal movement and plays the corresponding animation
       * Pre-condition: The player must exist and arrow keys must be pressed
       * Post-condition: The animation for the player's left and right movement plays
       * @param none
       * @return none
       */
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Mathf.Abs(horizontalMove) < 0.1f)
        {
            MusicSource.clip = walking; //sets the clip and plays the sound effect from the source
            MusicSource.Play();
        }
        


        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.R))
        {
            jump = true;
            animator.SetBool("Isjumping", true);
            
        }
        //Set the inventory images to true or false depending on whether or not the player
        //has those items
        if (hasApple || hasApple2)
        {
            AppleImage.SetActive(true);
        }
        else
        {
            AppleImage.SetActive(false);
        }

        if (hasWheat)
        {
            WheatImage.SetActive(true);
        }
        else
        {
            WheatImage.SetActive(false);
        }

    }

    /**
       * Description: Upon landing, the player stops jump and climb animation
       * Pre-condition: The player must land first
       * Post-condition: The animations stop playing for jump and climb
       * @param none
       * @return none
       */
    public void OnLanding ()
    {
        jump = false;
        animator.SetBool("isClimbing", false);
        animator.SetBool("IsJumping", false);
    }

    /**
       * Description: The bulk of the movement, moving left and right, Flipping the character when they're facing another direction, 
       * Checking for ladders and wheat and apples etc.
       * Pre-condition: The player must exist all the objects they're interacting with must exist
       * Post-condition: The player will interact with these objects and perform actions with them
       * @param none
       * @return none
       */
    void FixedUpdate()
    {
        //Checking to make sure the player isn't waiting
        if (!Input.GetKey(KeyCode.Space)) {

            //The input will come from the arrow keys or a and d
            inputHorizontal = Input.GetAxisRaw("Horizontal");

            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !m_FacingRight)
            {
                Flip();
            }
            else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && m_FacingRight)
            {
                Flip();
            }




            rb.velocity = new Vector2(inputHorizontal * maxSpeed, rb.velocity.y);


            //See if the player is interacting with a ladder and if they are, then have climb animation play
            //and have them move up the ladder
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

            if (hitInfo.collider != null)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    isClimbing = true;
                    animator.SetBool("isClimbing", true);

                }

            }
            else
            {

                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    isClimbing = false;
                    animator.SetBool("isClimbing", false);
                }
            }

            if (isClimbing == true && hitInfo.collider != null)
            {
                inputVertical = Input.GetAxisRaw("Vertical");
                rb.velocity = new Vector2(rb.velocity.x, inputVertical * verticalSpeed);
                rb.gravityScale = 0;
            }
            else if (isClimbing = false && hitInfo.collider == null)
            {
                rb.gravityScale = 3;
                isClimbing = false;
                animator.SetBool("isClimbing", false);
            }
            else
            {
                rb.gravityScale = 3;
            }

            if(rb.velocity.y < -16)
            {
                rb.velocity = new Vector2(rb.velocity.x, -16);
            }







            //See if the player is by the apple and can pick it up, if he can, pick it up
            RaycastHit2D hitInfoApple = Physics2D.Raycast(transform.position, Vector2.down, distance_y, whatIsApple);
            if (hitInfoApple.collider != null && !hasApple)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hasApple = true;
                }

            }

            else if (hasApple && hitInfoApple.collider == null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Instantiate(Tree, new Vector3(this.transform.position.x + 3.5f, this.transform.position.y - 0.2f, this.transform.position.z), Quaternion.identity);
                    hasApple = false;
                }

            }

            //See if the player is by the wheat and can pick it up, if he can, pick it up

            RaycastHit2D hitInfoWheat = Physics2D.Raycast(transform.position, Vector2.down, distance_y, whatIsWheat);
            if (hitInfoWheat.collider != null && !hasWheat)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    hasWheat = true;
                }

            }

            else if (hasWheat && hitInfoWheat.collider == null)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Instantiate(Wheat, new Vector3(this.transform.position.x, this.transform.position.y-0.5f, this.transform.position.z), Quaternion.identity);
                    hasWheat = false;
                }

            }

            //See if the player is by the second apple and can pick it up, if he can, pick it up

            RaycastHit2D hitInfoApple2 = Physics2D.Raycast(transform.position, Vector2.down, distance_y, whatIsApple2);
            if (hitInfoApple2.collider != null && !hasApple2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hasApple2 = true;
                }

            }

            else if (hasApple2 && hitInfoApple2.collider == null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Instantiate(Tree2, new Vector3(this.transform.position.x + 3.5f, this.transform.position.y - 0.2f, this.transform.position.z), Quaternion.identity);
                    hasApple2 = false;
                }

            }

            //if the season isn't fall then the wheat should disappear
            if(Current_Time.GetSeason() != "Fall")
            {
                hasWheat = false;
            }

            
            


        }

        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
