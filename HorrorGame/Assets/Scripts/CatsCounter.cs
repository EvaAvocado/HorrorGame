using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class CatsCounter : MonoBehaviour
{
    [SerializeField] private List<CatButton> _catsList;
    [SerializeField] private Text _text;
    [SerializeField] private Flowchart _flowchartEnds;

    private int _counter;

    public void CheckCatsStatus()
    {
        foreach (var catButton in _catsList)
        {
            catButton.LoadVariable();
            
            if (catButton.isActivated)
            {
                _counter++;
            }
        }

        _text.text = _counter + "/10";

        if (_counter >= 10) OpenSecretEnd();
        else
        {
            ExitSecretEnd();
        }
    }

    public void ResetValues()
    {
        foreach (var catButton in _catsList)
        {
            catButton.ResetVariable();
        }
    }

    private void OpenSecretEnd()
    {
        _flowchartEnds.ExecuteBlock("SetValuesSecretEndTrue");
    }
    
    private void ExitSecretEnd()
    {
        _flowchartEnds.ExecuteBlock("SetValuesSecretEndFalse");
    }
}