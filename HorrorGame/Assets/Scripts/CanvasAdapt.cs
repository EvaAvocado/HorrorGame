using GamePush;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAdapt : MonoBehaviour
{
    [SerializeField] private bool _isFungus;
    
    private CanvasScaler _canvasScaler;
    

    private void Awake()
    {
        _canvasScaler = GetComponent<CanvasScaler>();
        Adapt();
    }

    private void Adapt()
    {
        if (_isFungus) _canvasScaler.matchWidthOrHeight = GP_Device.IsMobile() ? 0.8f : 1;
        else _canvasScaler.matchWidthOrHeight = GP_Device.IsMobile() ? 0 : 1;
    }
}
