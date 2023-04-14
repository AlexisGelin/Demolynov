using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;

    Tweener _shakeTween;
    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    private void Awake()
    {
        cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity)
    {
        if (_shakeTween.IsActive()) _shakeTween.Kill();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }

    public void StopShake()
    {
        if (_shakeTween.IsActive()) _shakeTween.Kill();

        _shakeTween = DOVirtual.Float(cinemachineBasicMultiChannelPerlin.m_AmplitudeGain, 0, .1f, x => cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = x);
    }
}
