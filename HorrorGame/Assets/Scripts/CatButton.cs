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

    public void LoadVariable()
    {
        // Test
        // PlayerPrefs.SetInt(_name, 0);
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
            SaveSettings();
        }
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetInt(_name, 1);
    }

    public void Print()
    { 
        Debug.Log("Tap");
    }
}
