using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScore : MonoBehaviour {

    private Rigidbody2D rb;
    private float directionX, directionY, moveSpeed;

    private void Start () {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
    }

    private void Update () {
        directionX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        directionY = Input.GetAxisRaw("Vertical") * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionX, directionY);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionX, directionY);
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