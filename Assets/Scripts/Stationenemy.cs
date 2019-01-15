using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stationenemy : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the thing that we collided with
        //is the player (aka has the player script)
        Player playerScript = collision.collider.GetComponent<Player>();

        //Only do someting if the thing we ran into
        //was the player
        //aka playerScript is not null
        if (playerScript != null)
        {
            //We did hit the player
            //Kill them
            playerScript.Kill();
            
        }
    }

}
