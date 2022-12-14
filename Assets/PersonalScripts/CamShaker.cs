using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamShaker : MonoBehaviour
{
    public static CamShaker Instance { get; private set; }
    CinemachineVirtualCamera _vCam;
    [SerializeField] float _startingIntensity;
    [SerializeField] float _shakeTimerTotal;
    [SerializeField] float _shakeTimer;
    void Awake()
    {
        Instance = this;
        _vCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        var basicPerlin = _vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        basicPerlin.m_AmplitudeGain = intensity;
        _shakeTimer = time;
        _shakeTimerTotal = time;
        _startingIntensity = intensity;
    }

    void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;
        }
        if (_shakeTimer <= 0f)
        {
            var basicPerlin = _vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            basicPerlin.m_AmplitudeGain = 0f;
        }
    }
}
