using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    // Variable to let us add to the score 
    //      Public so we can drag and drop
    public Score scoreObject;

    public AudioSource Pickup;

    // Variable to hold the coin's value
    //      Public so we can change the it in the editor
    public int collectableValue;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Unity calls this function when our coin touches any other object
    //      If the player touched us, the coin should vanish and score will go up
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the thing we touched was the player
        Player playerScript = collision.collider.GetComponent<Player>();

        // If the thing we touched HAS a player script, that means
        // it is a player, so...
        if (playerScript)
        {
            // We hit the player!

            Pickup.Play();

            // Add to the score based on our value
            scoreObject.AddScore(collectableValue);

            // Destroy the gameObject that this script is attached to
            //      (the coin)
            Destroy(gameObject);
        }
    }


}