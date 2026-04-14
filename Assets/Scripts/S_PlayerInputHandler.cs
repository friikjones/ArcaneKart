using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField]
    private InputActionAsset playerControls;

    [Header("Action Map Name Reference")]
    [SerializeField]
    private string actionMapName = "Player"; // Default action map name

    [Header("Action Name Reference")]
    [SerializeField]
    private string move = "Move"; // Default move action name
    [SerializeField]
    private string shoot = "Shoot"; // Default move action name

    private InputAction moveAction; // Reference to the move action
    private InputAction shootAction; // Reference to the shoot action

    public Vector2 MoveInput { get; private set; } // Property to store move input
    public bool ShootInput { get; private set; } // Property to store shoot input

    public static S_PlayerInputHandler Instance { get; private set; } // Singleton instance

    private void Awake()
    {
        // Implementing Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        shootAction = playerControls.FindActionMap(actionMapName).FindAction(shoot);

        RegisterInputActions();
    }

    void RegisterInputActions()
    {
        moveAction.performed += ctx => MoveInput = ctx.ReadValue<Vector2>(); // Update move input when action is performed
        moveAction.canceled += ctx => MoveInput = Vector2.zero; // Reset move input when action is canceled

        shootAction.performed += ctx => ShootInput = true; // Set shoot input to true when action is performed
        shootAction.canceled += ctx => ShootInput = false; // Set shoot input to false when action is canceled
    }

    private void OnEnable()
    {
        moveAction.Enable();
        shootAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        shootAction.Disable();
    }
}
