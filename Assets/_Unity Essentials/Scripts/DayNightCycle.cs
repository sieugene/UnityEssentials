using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("The duration of a full day in seconds.")]
    public float dayDurationInSeconds = 60f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation speed based on the duration of a day
        float rotationSpeed = 360f / dayDurationInSeconds;

        // Rotate the light around its X-axis to simulate the day-night cycle
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
