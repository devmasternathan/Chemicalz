using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //-- initialize block elements used to 
    //-- visual see the order of the elements
    //-- selected.
    int i;
    int num;
    bool winstate;
    GameObject block1;
    GameObject block2;
    GameObject block3;
    GameObject block4;
    GameObject block5;
    GameObject block6;
    GameObject block7;
    GameObject block8;
    GameObject block9;

    //-- list of all chemical compounds.
    string order;
    List<string> win;

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
    public AudioSource collisionSound;

    //-- text element
    public Text text;
    public Text nametext;
   // ScoreKeeper keeper;

    //-- Use this for initialization
    void Start()
    {
    //    keeper = new ScoreKeeper();
	//	keeper.
        //---------------------------------------------------------------
        //-- if the object is null the populate it.
        //---------------------------------------------------------------
        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
        }

        if(text == null)
        {
            text = GameObject.Find("score").GetComponent<Text>();
        }

        if (nametext == null)
        {
            nametext = GameObject.Find("playername").GetComponent<Text>();
        }

        if (block1 == null)
        {
            block1 = GameObject.FindGameObjectWithTag("blockA");
            if (GameObject.FindGameObjectWithTag("blockA") != null)
                num++;
        }

        if (block2 == null)
        {
            block2 = GameObject.FindGameObjectWithTag("blockB");
            if (GameObject.FindGameObjectWithTag("blockB") != null)
                num++;
        }

        if (block3 == null)
        {
            block3 = GameObject.FindGameObjectWithTag("blockC");
            if (GameObject.FindGameObjectWithTag("blockC") != null)
                num++;
        }
        if (block4 == null)
        {
            block4 = GameObject.FindGameObjectWithTag("blockD");
            if (GameObject.FindGameObjectWithTag("blockD") != null)
                num++;
        }

        if (block5 == null)
        {
            block5 = GameObject.FindGameObjectWithTag("blockE");
            if (GameObject.FindGameObjectWithTag("blockE") != null)
                num++;
        }

        if (block6 == null)
        {
            block6 = GameObject.FindGameObjectWithTag("blockF");
            if (GameObject.FindGameObjectWithTag("blockF") != null)
                num++;
        }
        if (block7 == null)
        {
            block7 = GameObject.FindGameObjectWithTag("blockG");
            if (GameObject.FindGameObjectWithTag("blockG") != null)
                num++;
        }

        if (block8 == null)
        {
            block8 = GameObject.FindGameObjectWithTag("blockH");
            if (GameObject.FindGameObjectWithTag("blockH") != null)
                num++;
        }

        if (block9 == null)
        {
            block9 = GameObject.FindGameObjectWithTag("blockI");
            if (GameObject.FindGameObjectWithTag("blockI") != null)
                num++;
        }

        if(collisionSound == null)
        {
            collisionSound = GetComponent<AudioSource>();
        }
        //---------------------------------------------------------------

        //---------------------------------------------------------------
        //-- 
        //---------------------------------------------------------------
        i = 0;
        force = 350.0f;
        isJumping = false;
        movementSpeed = 4.0f;
        isFacingRight = true;

        //---------------------------------------------------------------
        //-- 
        //---------------------------------------------------------------
        win = new List<string>();
        order = "";

        //---------------------------------------------------------------
        //-- winning chemical combinations.
        //---------------------------------------------------------------
        win.Add("carbon");
        win.Add("sodiumchlorine");
        win.Add("hydrogenhydrogenoxygen");
        win.Add("heliumneonargonkrypton");
        win.Add("carboncarbonhydrogenhydrogenhydrogenhydrogenoxygen");
        win.Add("carboncarbonhydrogenhydrogenhydrogenhydrogenhydrogennitrogenoxygen");
        //---------------------------------------------------------------

		nametext.text = "Player : " + PlayerPrefsHelper.getPlayerName();
    }

    //-- Update is called once per frame, better for input
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
		text.text = "Score : " + PlayerPrefsHelper.getPlayerScore();
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
            //SoundManager.instance.RandomizeSfx(collisionSound);
			//SoundManager.instance.PlaySingle(collisionSound);
            switch (i)
            {
                case 0:
                    block1.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                case 1:
                    block2.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                case 2:
                    block3.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                case 3:
                    block4.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                case 4:
                    block5.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                case 5:
                    block6.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                case 6:
                    block7.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                case 7:
                    block8.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                case 8:
                    block9.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
            }

            order += other.name.ToLower();
            other.GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<BoxCollider2D>().enabled = false;
            i++;
			PlayerPrefsHelper.incrementScore(1);
            num--;
            collisionSound.Play();
            //print("element numbers : " + order);
            //print("total number of blocks : " + num);
            //print("score : " + PlayerPrefsHelper.getPlayerScore());

            //-- depending on the number of blocks make sure that the chemical 
            //-- compounds are in the correct order. If they are load the next scene 
            //-- or restart the game.
            if (num == 0)
            {
                collisionSound.Play();
                for (int j = 0; j < win.Count; j++)
                {
                    if (order.CompareTo(win[j]) == 0)
                    {
                        winstate = true;
                        break;
                    }
                }
                if (winstate)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
					PlayerPrefsHelper.incrementScore (5);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
					PlayerPrefsHelper.decreaseScore (2);
                }

            }



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