using UnityEngine;
using TMPro;

public class TiltAngleDebugger : MonoBehaviour
{
    public Transform headTransform;
    public TMP_Text debugText;
    public float tiltThreshold = 20f;
    public float holdTime = 3f;

    private float tiltTimer = 0f;
    private string lastGesture = "";
    private bool hasTriggered = false;

    void Update()
    {
        if (headTransform == null || debugText == null) return;

        float zRotation = headTransform.eulerAngles.z;
        zRotation = (zRotation > 180f) ? zRotation - 360f : zRotation;

        string gesture = "";
        if (zRotation > tiltThreshold) gesture = "Izquierda";
        else if (zRotation < -tiltThreshold) gesture = "Derecha";
        else
        {
            tiltTimer = 0;
            lastGesture = "";
            hasTriggered = false;
            gesture = "Neutral";
        }

        if (gesture != "Neutral")
        {
            if (gesture != lastGesture)
            {
                tiltTimer = 0;
                lastGesture = gesture;
            }

            if (!hasTriggered)
            {
                tiltTimer += Time.deltaTime;
                if (tiltTimer >= holdTime)
                {
                    hasTriggered = true;
                }
            }
        }

        debugText.text =
            $"zRotation: {zRotation:F1}°\n" +
            $"Gesto: {gesture}\n" +
            $"Temporizador: {tiltTimer:F2}s\n" +
            $"Umbral: ±{tiltThreshold}°\n" +
            $"Acción lista: {(hasTriggered ? "OK" : "SP")}";
    }
}
