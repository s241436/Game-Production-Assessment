using UnityEngine;

public class CarRumble : MonoBehaviour
{
    [Header("Rumble Settings")]
    public float rumbleAmount = 0.05f; // how much the car shakes
    public float rumbleSpeed = 4f;     // how fast it shakes

    private Vector3 originalPos;
    private float timeOffset;

    void Start()
    {
        originalPos = transform.localPosition;
        timeOffset = Random.value * 10f; // makes each car unique if multiple exist
    }

    void Update()
    {
        float rumbleX = (Mathf.PerlinNoise(Time.time * rumbleSpeed + timeOffset, 0f) - 0.5f) * rumbleAmount;
        float rumbleY = (Mathf.PerlinNoise(0f, Time.time * rumbleSpeed + timeOffset) - 0.5f) * rumbleAmount;

        transform.localPosition = originalPos + new Vector3(rumbleX, rumbleY, 0f);
    }

    public void EngineOff()
    {
        transform.localPosition = originalPos; // reset when turning off engine
        enabled = false;
    }
}