using System.Runtime.InteropServices;
using UnityEngine;


public class S_CameraBehaviour : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float smoothSpeed; // Smoothing factor for camera movement
    public Vector3 offset; // Offset from the player's position

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            // If the player reference is not set, try to find the player GameObject by tag
            player = GameObject.FindGameObjectWithTag("Player");
        }
        offset = transform.position - player.transform.position; // Calculate the initial offset between the camera and the player
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float chaseSpeed = Vector3.Distance(transform.position, player.transform.position + offset) * smoothSpeed; // Adjust the smooth speed based on the distance to the player
            // Desired position is the player's position plus the initial offset
            Vector3 desiredPosition = player.transform.position + offset;
            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, chaseSpeed);
            // Update the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}
