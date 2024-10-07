using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; // Reference to the CharacterController component

    public float speed = 6f; // Movement speed
    public float gravity = -9.81f; // Gravity value
    public float jumpHeight = 2f; // Jump height

    public Transform groundCheck; // Reference to the GroundCheck object
    public float groundDistance = 0.4f; // GroundCheck radius
    public LayerMask groundMask; // Layer mask to define what is considered ground

    Vector3 velocity; // Tracks the player's velocity
    bool isGrounded; // Whether the player is grounded

    void Update()
    {
        // Ground check: if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset vertical velocity when grounded to prevent accumulation of gravity
        }

        // Get input for movement along the X and Z axes
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Move the player based on input
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Jumping logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Apply jump force
        }

        // Apply gravity
        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
