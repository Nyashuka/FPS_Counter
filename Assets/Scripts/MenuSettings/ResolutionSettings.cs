using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;

    private Resolution[] resolutions;

    private void Start()
    {
        _dropdown.ClearOptions();    

        _dropdown.AddOptions(GetResolutionTitles().ToList());

        _dropdown.value = GetCurrentResolution();
    }

    private string[] GetResolutionTitles()
    {
        resolutions = Screen.resolutions.Distinct().ToArray();

        string[] resolutionTitles = new string[resolutions.Length];
        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionTitles[i] = resolutions[i].width + "x" + resolutions[i].height;
        }

        return resolutionTitles;
    }

    private int GetCurrentResolution()
    {
        for (int i = 0; i < _dropdown.options.Count; i++)
        {
            string[] curRes = _dropdown.options[i].text.Split('x');
            if (int.Parse(curRes[0]) == Screen.currentResolution.width && int.Parse(curRes[1]) == Screen.currentResolution.height)
                return i;
        }

        return _dropdown.options.Count - 1;
    }

    public void ChangeResolution()
    {
        Screen.SetResolution(resolutions[_dropdown.value].width, resolutions[_dropdown.value].height, true);
    }
}
