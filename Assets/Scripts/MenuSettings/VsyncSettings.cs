using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VsyncSettings : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;

    private void Start()
    {
        _dropdown.ClearOptions();

        List<string> options = new List<string>();
        options.Add("Off");
        options.Add("Level 1");
        options.Add("Level 2");
        
        _dropdown.AddOptions(options);

        _dropdown.value = QualitySettings.vSyncCount;
    }

    public void ChangeVsyncLevel()
    {
        QualitySettings.vSyncCount = _dropdown.value;
    }
}
