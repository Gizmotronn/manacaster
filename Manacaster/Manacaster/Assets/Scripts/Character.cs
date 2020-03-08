using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an abstract class that all characters needs to inherit from
/// </summary>
public abstract class Character : MonoBehaviour {

    /// <summary>
    /// The Player's movement speed
    /// </summary>
    [SerializeField]
    private float speed;

    private Animator myAnimator;

    /// <summary>
    /// The Player's direction
    /// </summary>
    protected Vector2 direction;

    private Rigidbody2D myRigidBody;

    public bool IsMoving // If player is moving or not
    {
        get 
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

    // Use this for initialization
    protected virtual void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	/// <summary>
    /// Update is marked as virtual, so that we can override it in the subclasses
    /// </summary>
	protected virtual void Update ()
    {
        // Move(); See in FixedUpdate()
        HandleLayers();
	}

    private void FixedUpdate() // Used when manipulate w/ rigid body - 2.2
    {
        Move();
    }

    /// <summary>
    /// Moves the player
    /// </summary>
    public void Move()
    {
        //Makes sure that the player moves # was: transform.Translate(direction * speed * Time.deltaTime);
        myRigidBody.velocity = direction.normalized * speed;

        //Press 2 keys, (direction) x=2,y=2 // Normalize = 1, 1
    }

    public void HandleLayers() // Handle animation layers
    {
        if (IsMoving)  // If the x-direction or y-direction of the game object (e.g player) is not 0, then go to next line and follow instructions ## If it is not 0, the object is moving in some way!
        {
            //Animate's the Player's movement
            //AnimateMovement(direction);
            ActivateLayer("WalkLayer"); //myAnimator.SetLayerWeight(1,1); // # inscope.me 1.3 ## Sets the second animator layer (walk_layer - index values python) to the active layer when the key input to walk is found
        
            //Sets the animation parameter so that he faces the correct direction
            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);
        }
        else // if the object is NOT moving ## object/game-object
        {
            {
                //myAnimator.SetLayerWeight(1, 0); // Set back to the idle layer
                ActivateLayer("IdleLayer:");
            }
        }

    }

    public void ActivateLayer(string layerName) //## https://acord.software/stellarios/inscoperpg2dot1 2.2 inscope.me
    {
        for (int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName),1);
    }
}
