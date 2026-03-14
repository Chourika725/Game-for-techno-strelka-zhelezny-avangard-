using UnityEngine;

public class CameraControll : MonoBehaviour
{
    // The object the camera will follow (e.g., the player)
    public Transform target;

    // The desired height of the camera above the target
    public float height = 20.0f;

    // The desired distance of the camera behind (or in front of) the target
    public float distance = 15.0f;

    // Adjust this value in the Inspector to control the smoothness of the camera movement
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // LateUpdate is called after all Update functions have been called
    // This ensures the player has moved for the current frame before the camera moves
    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position
            Vector3 desiredPosition = target.position;
            desiredPosition.y += height;
            desiredPosition.z -= distance; // Adjust Z position for 3D perspective

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

            // Make the camera look at the target
            transform.LookAt(target.position);
        }
    }
}
