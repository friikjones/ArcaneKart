using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerBehaviour : MonoBehaviour
{

    [Header("Movement Speed")]
    [SerializeField] private float movementSpeed = 5f; // Speed at which the player moves
    [SerializeField] public float maxSpeed = 10f; // Maximum speed the player can reach
    [SerializeField] private float dashSpeed = 10f; // Speed at which the player dashes
    [SerializeField] private float dashDuration = 0.2f; // Duration of the dash in seconds

    private Camera mainCamera; // Reference to the main camera
    public S_PlayerInputHandler inputHandler; // Reference to the player input handler
    private Rigidbody playerRigidbody; // Reference to the player's Rigidbody component

    public bool isometricMovement = false; // Flag to determine if movement is isometric

    public GameObject playerMesh;

    void Awake()
    {

    }

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
        playerMesh.transform.parent = null; // Detach the player mesh from the player GameObject to prevent it from being affected by physics forces
        mainCamera = Camera.main; // Get the main camera
        inputHandler = S_PlayerInputHandler.Instance; // Get the singleton instance of the input handler
        if (inputHandler == null)
        {
            Debug.LogError("PlayerInputHandler instance not found. Please ensure it is present in the scene.");
        }
    }


    // Update is called once per frame
    void Update()
    {

        HandleMovement(); // Handle player movement based on input
        HandleShooting(); // Handle player shooting based on input
    }


    void HandleMovement()
    {
        var forward = mainCamera.transform.forward; // Get the forward direction of the camera
        forward.y = 0; // Flatten the forward vector to the horizontal plane
        forward.Normalize(); // Normalize the forward vector to maintain consistent movement speed
        if (isometricMovement)
        {
            forward = Quaternion.Euler(0, 45, 0) * forward;
        }
        float angle = Vector3.SignedAngle(Vector3.forward, forward, Vector3.up); // Calculate the angle between the world forward vector and the camera's forward vector

        Vector2 moveInput = inputHandler.MoveInput; // Get the current move input from the input handler

        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y); // Calculate movement vector based on input and movement speed
        movement = Quaternion.Euler(0, angle, 0) * movement * movementSpeed * Time.deltaTime;
        if (playerRigidbody.linearVelocity.magnitude < maxSpeed)
        {
            playerRigidbody.AddForce(movement, ForceMode.VelocityChange); // Apply the movement force to the player's Rigidbody
        }

        // Handle mesh rotation and position
        playerMesh.transform.position = transform.position; // Update the position of the player mesh to match the player's position
        if (playerRigidbody.linearVelocity.magnitude > 0.1f) // Check if the player is moving
        {
            playerMesh.transform.rotation = Quaternion.LookRotation(movement.normalized); // Rotate the player mesh to face the direction of movement
        }

    }

    void HandleShooting()
    {
        Debug.Log($"Shoot Input: {inputHandler.ShootInput}"); // Log the shoot input for debugging purposes
        if (inputHandler.ShootInput) // Check if the shoot input is active
        {
            // Handle shooting logic
        }
    }

}
