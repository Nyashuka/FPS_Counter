using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;

    private void Start()
    {
        _dropdown.ClearOptions();
        Resolution[] resolutions = Screen.resolutions;
        resolutions.Distinct<Resolution>().ToArray();

        string[] resolutionTitles = new string[resolutions.Length];
        for(int i = 0; i < resolutions.Length; i++)
        {
            resolutionTitles[i] = resolutions[i].ToString();
        }
        

        _dropdown.AddOptions(resolutionTitles.ToList());

    }

    public void ChangeResolution()
    {

    }
}
