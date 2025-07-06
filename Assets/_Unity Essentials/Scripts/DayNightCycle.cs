using UnityEngine;

/// <summary>
/// Attach this script to a Directional Light to simulate a day-night cycle.
/// The light will rotate around the world's X-axis to mimic the sun rising and setting.
/// </summary>
public class DayNightCycle : MonoBehaviour
{
    [Tooltip("The number of real-world seconds it takes for a full in-game day to pass.")]
    public float dayDurationInSeconds = 120f; // Default to a 2-minute day

    // We will rotate the light around the world's X axis.
    private Vector3 rotationAxis = Vector3.right;

    void Update()
    {
        // Ensure the duration is not zero to avoid division by zero errors.
        if (dayDurationInSeconds <= 0)
        {
            return;
        }

        // 1. Calculate the rotation speed in degrees per second.
        // A full circle is 360 degrees.
        float rotationSpeed = 360f / dayDurationInSeconds;

        // 2. Calculate the rotation amount for this frame.
        // Time.deltaTime is the time in seconds since the last frame.
        // This makes the rotation smooth and independent of the frame rate.
        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        // 3. Apply the rotation to the light's transform.
        // We rotate around the world's X-axis (Vector3.right) to simulate sunrise and sunset.
        // Using Space.World ensures the light orbits the world, not just spins on its local axis.
        transform.Rotate(rotationAxis, rotationThisFrame, Space.World);
    }
}