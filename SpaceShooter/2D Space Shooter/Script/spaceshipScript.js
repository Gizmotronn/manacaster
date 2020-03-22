// Function called about 60 times per second
function Update() {
    // Get the rigidbody component
    var r2d = GetComponent("Rigidbody2D");

    // Move the spaceship when an arrow key is pressed
    if (Input.GetKey("right"))
        r2d.velocity.x = 10;
    else if (Input.GetKey("left"))
        r2d.velocity.x = -10;
    else
        r2d.velocity.x = 0;
} 