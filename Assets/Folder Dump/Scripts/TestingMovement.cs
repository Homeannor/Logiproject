using UnityEngine;

public class TestingMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 180f;
    public Rigidbody rb;

    public float jumpForce = 5f;
    public bool grounded = true;

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        transform.Rotate(0f, rotateInput * rotationSpeed * Time.deltaTime, 0f);

        rb.linearVelocity = new Vector3(
            transform.forward.x * moveInput * moveSpeed,
            rb.linearVelocity.y,
            transform.forward.z * moveInput * moveSpeed
        );

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
    }
}