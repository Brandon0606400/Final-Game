using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the thing that we collided with
        //is the player (aka has the player script)
        MovingEnemy movingEnemyScript = collision.collider.GetComponent<MovingEnemy>();

        //Only do someting if the thing we ran into
        //was the player
        //aka playerScript is not null
        if (movingEnemyScript != null)
        {
            //We did hit the player
            //Kill them
            movingEnemyScript.killFly();
            Destroy(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

}
