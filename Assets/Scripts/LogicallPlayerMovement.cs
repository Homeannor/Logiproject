/*
* Created by I_Logicall (aka HOME_NOR) on 30th May 2026
* Tutorial Link: https://www.youtube.com/shorts/XlgTt5A9NHY
* The Dev Mafia Discord: https://discord.gg/9TNSu9bGBW

* This is a simple player movement script which allows the player to move, turn, and jump using WASD and Spacebar
* If you are using this script, make sure to follow the Tutorial carefully and set up the following things:
* - 1. A Rigidbody Component in your Player GameObject (which is dragged into the "rb" variable in the Inspector)
* - 2. A Collider Component in your Player GameObject (which is not set to "Is Trigger")
* - 3. A floor GameObject with the tag "Floor" which has been added in the Inspector

* If you have any questions, you're more than welcome to join The Dev Mafia Discord and ask in the #❓│dev-help channel!
* 💛 Thanks for using this script and happy developing!
*/

using UnityEngine;

public class LogicallPlayerMovement : MonoBehaviour
{
    // Movement Variables
    public float moveSpeed = 10f;
    public float rotationSpeed = 180f;
    public Rigidbody rb;

    // Jumping Variables
    public float jumpForce = 5f;
    public bool grounded = true;

    void Update()
    {
        // Getting the input axis for movement and rotation
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        // Rotating the player on the Y axis based on the horizontal input
        transform.Rotate(0f, rotateInput * rotationSpeed * Time.deltaTime, 0f);

        // Moving the player forward (locally) based on the vertical input
        rb.linearVelocity = new Vector3(
            transform.forward.x * moveInput * moveSpeed,
            rb.linearVelocity.y,
            transform.forward.z * moveInput * moveSpeed
        );

        // Allowing the player to jump if they're on the ground and pressed Space!
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Collision detection to check if the player is on the ground or not
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
    }
}