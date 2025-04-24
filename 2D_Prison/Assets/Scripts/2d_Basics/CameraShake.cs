using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraShake : MonoBehaviour
{
    private CinemachineBasicMultiChannelPerlin perlin;
    private bool isShaking = false;
    private float shakeTimer = 0f;

    [Header("Shake Settings")]
    public float shakeDuration = 0.5f; // Duration of the shake effect
    public float shakeAmplitude = 1f;  // Shake intensity
    public float shakeFrequency = 2f;  // Shake frequency (speed)

    void Start()
    {
        // Get the Perlin noise component from the Cinemachine Virtual Camera
        perlin = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = 0f;  // Start with no shake
        perlin.m_FrequencyGain = 0f;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                // Reset the shake
                perlin.m_AmplitudeGain = 0f;
                perlin.m_FrequencyGain = 0f;
                isShaking = false;
            }
        }
    }

    // Function to trigger the camera shake
    public void TriggerShake()
    {
        if (!isShaking)
        {
            perlin.m_AmplitudeGain = shakeAmplitude;
            perlin.m_FrequencyGain = shakeFrequency;
            shakeTimer = shakeDuration;
            isShaking = true;
        }
    }
}
