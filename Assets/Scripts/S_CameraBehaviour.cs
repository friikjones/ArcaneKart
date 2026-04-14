using System.Runtime.InteropServices;
using UnityEngine;


public class S_CameraBehaviour : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float chaseSpeed; // Smoothing factor for camera movement
    public Vector3 offset; // Offset from the player's position

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            // If the player reference is not set, try to find the player GameObject by tag
            player = GameObject.FindGameObjectWithTag("Player");
        }
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            // Desired position is the player's position plus the initial offset
            Vector3 desiredPosition = player.transform.position + offset;
            Debug.DrawRay(transform.position, desiredPosition - transform.position, Color.red); // Draw a ray from the camera to the desired position for debugging
            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, chaseSpeed * Time.deltaTime);
            // Update the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}
