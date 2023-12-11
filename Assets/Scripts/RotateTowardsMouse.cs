using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ensure the z-coordinate is 0 (assuming your game is 2D)

        // Calculate the direction from the current position to the mouse position
        Vector3 direction = (mousePos - transform.position).normalized;

        // Calculate the angle between the current direction and the up vector
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        // Rotate the GameObject to face the mouse
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
