using UnityEngine;

public class AccelerometerTransformProxy : MonoBehaviour
{
    public float calibratedOffset = 0f;
    public float currentRoll = 0f;
    public bool calibrateOnStart = true;

    void Start()
    {
        if (calibrateOnStart)
        {
            Vector3 accel = Input.acceleration;
            calibratedOffset = GetRollFromAccel(accel);
        }
    }
    void Update()
    {
        Vector3 accel = Input.acceleration;
        float rawRoll = GetRollFromAccel(accel);
        currentRoll = rawRoll - calibratedOffset;
        Debug.Log($"[Roll lógico] {currentRoll:F1}°");
    }
    float GetRollFromAccel(Vector3 accel)
    {
        return Mathf.Atan2(accel.x, accel.z) * Mathf.Rad2Deg;
    }
}
