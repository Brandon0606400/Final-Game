using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour {

    public float speed;
    public Rigidbody2D physicsBody;
    public Collider2D playerCollider;
    private Transform target;
    public Enemyrespawn spawnpoint;
    
    public AudioSource EnemyHurt;

    // Use this for initialization
    void Start (){
        // Finds the player in the level
        target = GameObject.Find("Player").transform;

	}

    void Update()
    {
        // Moves towards the player
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the thing that we collided with
        //is the player (aka has the player script)
        Player playerScript = collision.collider.GetComponent<Player>();

        //Only do something if the thing we ran into
        //was the player
        //aka playerScript is not null
        if (playerScript != null)
        {
            //We did hit the player
            //Kill them
            playerScript.Kill();
        }
    }

    public void killFly()
    {
        //gets reference to script called "GameManager", and calls the SpawnAlien() function to respawn itself
        spawnpoint.Death = true;

        EnemyHurt.Play();

        

        //destroys itself after calling SpawnAlien() function
        Destroy(gameObject);
    }

}
