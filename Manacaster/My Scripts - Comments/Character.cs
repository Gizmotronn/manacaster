using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour // Abstract bc a character game object can't exist on it's own - the character [class] can't exist on it's own, but the player can and the enemy can. Character.cs is the overaching thing that all game objects inherit features from --> # affects game objects e.g. Enemy, Player game objects # adds functionality, moves it onto those game objects
{ // Some of these things were originally seen in player.cs - https://www.youtube.com/watch?v=GjTTqz39kLY

        /// <summary>
    /// The Player's movement speed
    /// </summary>
    [SerializeField]
    private float speed; // We can set the speed from the inspector. # This could be done with a "public" float, however we can serialize the field instead and keep it private # by keeping it as a private float, it prevents other game objects from accessing this # Only the player.cs script can access this field

    // Start is called before the first frame update
    //void Start();
    //{
        
    //}

    // Update is called once per frame
    protected virtual void Update() // update function is virtual --> #gameObjects affected by character.cs can override it ->#see player.cs "protected override void Update() to see an example of an override Update function
    {
        Move();
    } 

        /// <summary>
    /// The Player's direction
    /// </summary>
    protected Vector2 direction; // Decides where the "player" game object is moving # see private void GetInput() (line 42) # protected = accessible by everything that inherits from it (every game object) but can't be edited by these objects

    /// <summary>
    /// Moves the player
    /// </summary>
    public void Move()
    {
        //Makes sure that the player moves
        transform.Translate(direction*speed*Time.deltaTime);
    }
}
