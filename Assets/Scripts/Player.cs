using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extra using statement to allow us to use the scene management functions
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //designer variables
    public GameObject bullet;
    public float speed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public string shootButtonUp = "shootButtonUp";
    public string shootButtonDown = "shootButtonDown";
    public string shootButtonLeft = "shootButtonLeft";
    public string shootButtonRight = "shootButtonRight";

    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Collider2D playerCollider;

    public AudioSource Shoot;
    public AudioSource Death;

    // Variable to keep a reference to the lives display object
    public Lives LivesObject;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
                
        //Get Axis input from unity
        float leftRight = Input.GetAxis(horizontalAxis);
        float upDown = Input.GetAxis(verticalAxis);

        // Create Direction vector from axis input
        Vector2 direction = new Vector2(leftRight, upDown);

        // Make direction vector length 1
        direction = direction.normalized;

        // Calculate velocity
        Vector2 velocity = direction * speed;

        // Give the velocity to the rigidbody
        physicsBody.velocity = velocity;

        //Tell the animator our speed
        playerAnimator.SetFloat("Walk", Mathf.Abs(velocity.x));

        //Flip our sprite if we're moving backwards
        if (velocity.x < 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }

        //Shooting Code
        if (Input.GetButtonDown(shootButtonUp))

        {

            GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up * 1.5f, Quaternion.identity));

            Shoot.Play();

            b.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);

        }
        else if (Input.GetButtonDown(shootButtonDown))

        {

            GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up * -1.5f, Quaternion.identity));

            Shoot.Play();

            b.GetComponent<Rigidbody2D>().AddForce(transform.up * -1000);

        }
        else if (Input.GetButtonDown(shootButtonRight))

        {

            GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.right * 1.5f, Quaternion.identity));

            Shoot.Play();

            b.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);

        }
        else if (Input.GetButtonDown(shootButtonLeft))

        {

            GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.right * -1.5f, Quaternion.identity));

            Shoot.Play();

            b.GetComponent<Rigidbody2D>().AddForce(transform.right * -1000);

        }
    }

    public void Kill()
    {
        // Take away a life and save that change
        LivesObject.LoseLife();
        LivesObject.SaveLives();

        //Check if it's game over
        bool gameOver = LivesObject.IsGameOver();

        if (gameOver == true)
        {
            // If it IS game over...
            // Load the game over screen
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            // If it is NOT game over...
            // Reset the current level to restart from the beginning 


            //Reset the current level to restart from the beginning

            //First ask unity what the current level is
            Scene currentLevel = SceneManager.GetActiveScene();
            //Second, tell unity to load the current level again
            //by passing the build index of our level
            SceneManager.LoadScene(currentLevel.buildIndex);

            Death.Play();
        }
    }

}
