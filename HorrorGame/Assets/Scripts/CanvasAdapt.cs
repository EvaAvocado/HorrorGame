using System;
using GamePush;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAdapt : MonoBehaviour
{
    [SerializeField] private bool _isFungus;
    
    private CanvasScaler _canvasScaler;
    private bool _isMobile;

    private void Awake()
    {
        _canvasScaler = GetComponent<CanvasScaler>();
        Adapt();
    }

    private void Update()
    {
        if (_isMobile)
        {
            if (Screen.orientation is ScreenOrientation.Portrait or ScreenOrientation.PortraitUpsideDown)
            {
                _canvasScaler.matchWidthOrHeight = 0;
                if (_isFungus) _canvasScaler.matchWidthOrHeight = 0.8f;
            }
            else if (Screen.orientation is ScreenOrientation.LandscapeLeft or ScreenOrientation.LandscapeRight)
            {
                _canvasScaler.matchWidthOrHeight = 1;
            }
        }
    }

    private void Adapt()
    {
        _isMobile = GP_Device.IsMobile();
        if (_isFungus) _canvasScaler.matchWidthOrHeight = _isMobile ? 0.8f : 1;
        else _canvasScaler.matchWidthOrHeight = _isMobile ? 0 : 1;
    }
}
