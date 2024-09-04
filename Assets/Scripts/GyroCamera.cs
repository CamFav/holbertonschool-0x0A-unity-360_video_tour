using UnityEngine;

public class GyroscopeCamera : MonoBehaviour
{
    private Gyroscope gyro;
    private Quaternion baseRotation;

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            // Basic oriention of phone
            baseRotation = Quaternion.Euler(90f, 0f, 0f);
        }
        else
        {
            Debug.LogError("Gyroscope non supporté sur cet appareil.");
        }
    }

    private void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            // Get gyroscope data
            Quaternion gyroRotation = new Quaternion(-gyro.attitude.x, -gyro.attitude.y, gyro.attitude.z, gyro.attitude.w);
            
            // Correct oriention using the phone gyroscope data
            gyroRotation = Quaternion.Euler(0f, 0f, 0f) * gyroRotation; // Ajustez ces valeurs

            // Apply phone rotation to camera
            transform.localRotation = baseRotation * gyroRotation;
        }
    }
}
