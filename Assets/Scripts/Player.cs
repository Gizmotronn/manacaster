using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the player script, it contains functionality that is specific to the Player
/// </summary>
public class Player : Character
{
    /// <summary>
    /// The player's health
    /// </summary>
    [SerializeField] // Makes it private (not editable) but attaches it as an attribute to a gameObject
    private Stat health;

    /// <summary>
    /// The player's mana
    /// </summary>
    [SerializeField] // See line 13
    private Stat mana;

    /// <summary>
    /// The player's initialHealth
    /// </summary>
    private float initHealth = 100;

    /// <summary>
    /// The player's initial mana
    /// </summary>
    private float initMana = 50; // Not editable by gameObjects/inspector

    protected override void Start()
    {

        health.Initialize(initHealth, initHealth); // Pseudocode initialize
        mana.Initialize(initMana, initMana);

        base.Start();
    }

    /// <summary>
    /// We are overriding the characters update function, so that we can execute our own functions
    /// </summary>
    protected override void Update()
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

        ///THIS IS USED FOR DEBUGGING ONLY
        ///
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 10;
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

        if (Input.GetKeyDown(KeyCode.Space)) // only when key is pressed - not when held down
        {
            // Attack() // # Usually used to call functions
            StartCoroutine(Attack()); // Done in background - while the rest of the script is being run
        }
    }

    private IEnumerator Attack() // # Attack function
    {
        myAnimator.SetBool("attack",true); // # See in character script, as animator can't be reached by player # when starts attack, attacking boolean is set to true

        yield return new WaitForSeconds(3) // Wait 3 seconds - cast time # Hardcoded cast time, for debugging

        Debug.Log("done casting"); // After 3 seconds (see this private function) since you originally pressed the space bar (i.e. for the first time) it will print this message to the debug console
    } // if it was void (instead of IEnumerator), it wouldn't be able to do the WaitForSeconds
}
