using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /// <summary>
    /// The Player's movement speed
    /// </summary>
    [SerializeField]
    private float speed; // We can set the speed from the inspector. # This could be done with a "public" float, however we can serialize the field instead and keep it private # by keeping it as a private float, it prevents other game objects from accessing this # Only the player.cs script can access this field

    /// <summary>
    /// The Player's direction
    /// </summary>
    private Vector2 direction; // Decides where the "player" game object is moving # see private void GetInput() (line 42)



	// Update is called once per frame
	void Update ()
    {
        //Executes the GetInput function
        GetInput();

        //Executes the Move function
        Move();
	}

    /// <summary>
    /// Moves the player
    /// </summary>
    public void Move()
    {
        //Makes sure that the player moves
        transform.Translate(direction*speed*Time.deltaTime);
    }

    /// <summary>
    /// Listen's to the players input
    /// </summary>
    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) // If the key "w" is pressed # Not if it is held down, if it is pressed down once
        {
            direction += Vector2.up; // If the key "w" is pressed, the direction that the player game object will go is up # thanks to the vector 2 value
        }
        if (Input.GetKey(KeyCode.A)) // Direction is reset after every loop to keep the speed constant
        {
            direction += Vector2.left; // Everything in this loop (as in all 4 parts of the loop/options of the loop) behave in the same way
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }
}
