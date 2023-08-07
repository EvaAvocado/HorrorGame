using Fungus;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Flowchart _flowchartSettings;

    private void Start()
    {
        _flowchartSettings.ExecuteBlock("SetAudioOn");
    }
}
