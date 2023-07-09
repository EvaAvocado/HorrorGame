using UnityEngine;

public class CatButton : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private ParticleSystem _particle;
    
    public bool isActivated;

    private void Awake()
    {
        LoadVariable();
    }

    public void ResetVariable()
    {
        PlayerPrefs.SetInt(_name, 0);
        SaveSettingsFalse();
    }

    public void LoadVariable()
    {
        // Test
        // ResetVariable();
        // Test
        
        if (PlayerPrefs.HasKey(_name))
        {
            isActivated = PlayerPrefs.GetInt(_name) == 1;
        }
    }

    private void OnMouseUp()
    {
        if (!isActivated)
        {
            _particle.Play();
            Print();
            isActivated = true;
            SaveSettingsTrue();
        }
    }

    private void SaveSettingsTrue()
    {
        PlayerPrefs.SetInt(_name, 1);
    }
    
    private void SaveSettingsFalse()
    {
        PlayerPrefs.SetInt(_name, 0);
    }

    public void Print()
    { 
        Debug.Log("Tap");
    }
}
