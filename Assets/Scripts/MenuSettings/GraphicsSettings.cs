using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettings : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;

    private void Start()
    {
        _dropdown.ClearOptions();
        _dropdown.AddOptions(QualitySettings.names.ToList());
        _dropdown.value = QualitySettings.GetQualityLevel();
    }

    public void ChangeQuality()
    {
        QualitySettings.SetQualityLevel(_dropdown.value);
    }
}
