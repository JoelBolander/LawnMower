using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;  // The target GameObject that the camera will follow
    public float smoothSpeed = 0.125f;  // The smoothness of the camera movement

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3(0, 0, -10);  // Adjust the -10 based on your camera's z position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
