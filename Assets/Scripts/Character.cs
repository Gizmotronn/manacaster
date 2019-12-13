using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an abstract class that all characters needs to inherit from
/// </summary>
public abstract class Character : MonoBehaviour { // abstract classes have functionality, all characters (gameObjects w/ character class) inherit these functions

    /// <summary>
    /// The Player's movement speed
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// A reference to the character's animator
    /// </summary>
    protected Animator animator; // Animator = inspector Unity Editor  # Protected so that it can be accessed by Scripts/player.cs

    /// <summary>
    /// The Player's direction
    /// </summary>
    protected Vector2 direction;

    private Rigidbody2D myRigidbody;

    public bool IsMoving
    {
        get {
            return direction.x != 0 || direction.y != 0;
        }
    }

    protected virtual void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is marked as virtual, so that we can override it in the subclasses
    /// </summary>
    protected virtual void Update ()
    {
        // Move();
        HandleLayers();
	}

    private void FixedUpdate() // Should be used every time you manipulate rigid body
    {
        Move();
    }

    /// <summary>
    /// Moves the player
    /// </summary>
    public void Move()
    {
        //Makes sure that the player moves
        // Originally transform.Translate(direction * speed * Time.deltaTime);
        myRigidbody.velocity = direction.normalized * speed; // # uses physics system to move gameObject

        // 6:38 on inScope RPG Tutorial 2.2 https://www.youtube.com/watch?v=Y03jBu6enf8
    }

    public void HandleLayers() // handles animation layers
    {
        if (direction.x != 0 || direction.y != 0)
        {
            AnimateMovement(direction);
        }
        else
        {
            // Makes sure we will go back to IDLE when no key input found
            animator.SetLayerWeight(1, 0);
        }
    }


    /// <summary>
    /// Makes the player animate in the correct direction
    /// </summary>
    /// <param name="direction"></param>
    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);

        //Sets the animation parameter so that he faces the correct direction
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }
}
