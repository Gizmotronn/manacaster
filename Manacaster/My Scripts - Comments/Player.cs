using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character { //# Character.cs


	// Update is called once per frame
	protected override void Update ()
    {
        //Executes the GetInput function
        GetInput();


        base.update(); // Executes character.cs update - allows player game object to move

        //Executes the Move function --> see Character.cs script --> # in void Update()
       // Move();
	}



    /// <summary>
    /// Listen's to the players input
    /// </summary>
    private void GetInput() // This isn't move into Character.cs as the enemy doesn't need input, but it can be --> # if it was, every game object affected by "character.cs" would move in the same way -> # if you pressed the "w" key, these game objects would both move up regardless of their starting/initial positions
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