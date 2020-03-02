using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the player script, it contains functionality that is specific to the Player
/// </summary>
public class Player : Character
{
    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat mana;

    //[SerializeField]
    //private float healthValue;

   // [SerializeField]
    private float initHealth = 100;

    private float initMana = 50;

    protected override void Start()
    {
        health.Initialize(initHealth, initHealth); // Was 100, 100 // healthValue, maxHealth);
        mana.Initialize(initMana, initMana);

        base.Start();
    }

	/// <summary>
    /// We are overriding the characters update function, so that we can execute our own functions
    /// </summary>
	protected override void Update ()
    {
        //Executes the GetInput function
        GetInput();
        
        base.Update();
	}

    /// <summary>
    /// Listen's to the players input
    /// </summary>
    private void GetInput()
    {
        direction = Vector2.zero;

        // Debugging - inscope.me RPG 2.0
        if (Input.GetKeyDown(KeyCode.I));
        {
            health.MyCurrentValue -= 10; // Lose 10 health - player game object
            mana.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O));
        {
            health.MyCurrentValue += 10; // Add 10 health (see above ^^) - healing debug function
            mana.MyCurrentValue += 10; // ^^
        }


        if (Input.GetKey(KeyCode.W)) //Moves up
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A)) //Moves left
        {
            direction += Vector2.left; //Moves down
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D)) //Moves right
        {
            direction += Vector2.right;
        }
    }
}
