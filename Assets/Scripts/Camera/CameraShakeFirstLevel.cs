using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShakeFirstLevel : MonoBehaviour
{
    public static CameraShakeFirstLevel Instance { get; private set; }

    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCameraShakeEffect;
    CinemachineBasicMultiChannelPerlin cinemachineNoiseEffect;

    [SerializeField] GlitchActivationFirstLevel glitchEffectTriggerFirstLevel;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (cinemachineVirtualCameraShakeEffect != null)
        {
            cinemachineNoiseEffect = cinemachineVirtualCameraShakeEffect.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        else
        {
            Debug.LogError("Cinemachine Virtual Camera Shake Effect not assigned to CameraShake script.");
        }
    }

    private void Update()
    {

    }

    public void CameraShakeGradualIncrease(float intensity)
    {
        if (cinemachineNoiseEffect != null)
        {
            cinemachineNoiseEffect.m_AmplitudeGain = intensity;
        }
        else
        {
            Debug.LogError("Cinemachine Noise Effect is not assigned.");
        }
    }
}
