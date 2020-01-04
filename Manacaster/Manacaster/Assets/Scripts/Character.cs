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

    /// <summary>
    /// The Player's direction
    /// </summary>
    protected Vector2 direction;

    // Use this for initialization
    void Start () {
		
	}
	
	/// <summary>
    /// Update is marked as virtual, so that we can override it in the subclasses
    /// </summary>
	protected virtual void Update ()
    {
        Move();
	}

    /// <summary>
    /// Moves the player
    /// </summary>
    public void Move()
    {
        //Makes sure that the player moves
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
