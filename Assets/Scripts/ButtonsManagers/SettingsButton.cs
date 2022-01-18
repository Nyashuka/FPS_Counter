using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _graphicsSettingsPanel;
   

    public void OpenSettings()
    {
        _graphicsSettingsPanel.SetActive(true);
    }

    
}
