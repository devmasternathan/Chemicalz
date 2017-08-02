using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class PlayerController : MonoBehaviour
{
    //-- initialize block elements used to 
    //-- visual see the order of the elements
    //-- selected.
	private int elementBoxCounter;
	private GameObject[] blocks;

    //-- controls player movements and manage collision of the player
    //-- with other objects.
    private float force;
    private bool isJumping;
    private float horizontal;
    private bool isFacingRight;
    private Animator myAnimator;
    private float movementSpeed;
    private Rigidbody2D rigidBody;

    //-- Sound Effects
    public AudioClip moveSound;
    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public AudioClip collisionSound;


    //-- Use this for initialization
    void Start()
    {

   
        //---------------------------------------------------------------
        //-- if the object is null the populate it.
        //---------------------------------------------------------------
        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
        }

		// Populate blocks array with the black box objects
		blocks = GameObject.FindGameObjectsWithTag("block");

		GameObject temp;

		// Sort the box objects according to number on name
		for (int write = 0; write < blocks.Length; write++) {
			for (int sort = 0; sort < blocks.Length - 1; sort++) {
				if (int.Parse (Regex.Match (blocks[sort].name, @"\d+").Value) > int.Parse (Regex.Match (blocks[sort + 1].name, @"\d+").Value)) {
					temp = blocks[sort + 1];
					blocks[sort + 1] = blocks[sort];
					blocks[sort] = temp;
				}
			}
		}
			
		elementBoxCounter = 0;
        force = 350.0f;
        isJumping = false;
        movementSpeed = 4.0f;
        isFacingRight = true;

    }

    //-- Update is called once per frame, better for input
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    //-- FixedUpdate is better for physics and movement
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontal * movementSpeed, rigidBody.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            rigidBody.AddForce(new Vector2(0, force));
            isJumping = true;
        }

        if ((horizontal < 0 && isFacingRight) || (horizontal > 0 && !isFacingRight))
            Flip();
    }

    //-- reverse player direction.
    void Flip()
    {
        Vector3 playerScale = transform.localScale;
        playerScale.x = playerScale.x * -1;
        transform.localScale = playerScale;
        isFacingRight = !isFacingRight;
    }

    //-- handle the box touching movement.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("element"))
        {
            SoundManager.instance.RandomizeSfx(collisionSound);
			// Assign elements to the black box game object
			blocks[elementBoxCounter].GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
            other.GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<BoxCollider2D>().enabled = false;
			// Increment to assign next element to next box
			elementBoxCounter++;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Set Jumping to false if its colliding with platform
        if (other.gameObject.tag == "Platform")
        {
            isJumping = false; 
        }
    }
}