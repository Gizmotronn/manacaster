using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Autofill for commands, works well in Visual Studio

/// <summary>
/// This is the player script, it contains functionality that is specific to the Player
/// </summary>
public class Player : Character
{
    [SerializeField] // Makes it private but able to be accessed in the inspector -##- https://forum.unity.com/threads/when-to-use-serializefield-and-why.184687/ 
    private Stat health;

    [SerializeField]
    private Stat mana;

    //[SerializeField]
    //private float healthValue;

   // [SerializeField]
    private float initHealth = 100; // The initial health of the player is set to 100

    private float initMana = 50; // The initial mana of the player is set to 50

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

        private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.name) {
            case "Coin":
                Score.scoreAmount += 1;
                Destroy(collision.gameObject); // could also do animations here :)
                break;
            case "Coin - Copy":
                Score.scoreAmount += 2;
                Destroy(collision.gameObject); 
                break;
            case "Coin - Copy (2)":
                Score.scoreAmount += 3;
                Destroy(collision.gameObject);
                break;
                        
        }
    }
}
