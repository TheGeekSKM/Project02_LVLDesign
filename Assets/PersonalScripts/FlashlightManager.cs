using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    [SerializeField] Light _spotLight;
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _flashLightOnClip;
    [SerializeField] AudioClip _flashLightOffClip;
    bool _lightStatus = false;
    bool _runOnce = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            _lightStatus = !_lightStatus;

            _runOnce = false;
            if (!_runOnce)
            {
                HandleAudioFeedback();
                _runOnce = true;
            }
        }

        if (_lightStatus) _spotLight.intensity = 35f;
        else _spotLight.intensity = 0f;
    }

    void HandleAudioFeedback()
    {
        _source.Stop();
        if (_flashLightOffClip == null && _flashLightOnClip == null) return;

        if (_lightStatus) _source.PlayOneShot(_flashLightOnClip);
        else _source.PlayOneShot(_flashLightOffClip);
    }
}
