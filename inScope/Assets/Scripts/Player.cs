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
    [SerializeField]
    private Stat health;

    /// <summary>
    /// The player's mana
    /// </summary>
    [SerializeField]
    private Stat mana;

    /// <summary>
    /// The player's initialHealth
    /// </summary>
    private float initHealth = 100;

    /// <summary>
    /// The player's initial mana
    /// </summary>
    private float initMana = 50;

    /// <summary>
    /// Contain's all prefabs for the spells
    /// </summary>
    [SerializeField]
    private GameObject[] spellPrefab;

    /// <summary>
    /// Positions for creating our spells
    /// </summary>
    [SerializeField]
    private Transform[] exitPoints;

    /// <summary>
    /// Keeps track of which exit point to use 2 is defualt down
    /// </summary>
    private int exitIndex = 2;

    protected override void Start()
    {

        health.Initialize(initHealth, initHealth);
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
            exitIndex = 0;
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A)) //Moves left
        {
            exitIndex = 3;
            direction += Vector2.left; //Moves down
        }
        if (Input.GetKey(KeyCode.S))
        {
            exitIndex = 2;
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D)) //Moves right
        {
            exitIndex = 1;
            direction += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.Space)) //Makes the player attack
        {
            if (!isAttacking && !IsMoving) //Chcks if we are able to attack
            {
                attackRoutine = StartCoroutine(Attack());
            }
            
        }
    }

    /// <summary>
    /// A co routine for attacking
    /// </summary>
    /// <returns></returns>
    private IEnumerator Attack()
    {
        isAttacking = true; //Indicates if we are attacking

        myAnimator.SetBool("attack", isAttacking); //Starts the attack animation

        yield return new WaitForSeconds(1); //This is a hardcoded cast time, for debugging

        CastSpell();

        StopAttack(); //Ends the attack
    }

    /// <summary>
    /// Casts a spell
    /// </summary>
    public void CastSpell()
    {
        Instantiate(spellPrefab[0], exitPoints[exitIndex].position, Quaternion.identity);
    }

}
