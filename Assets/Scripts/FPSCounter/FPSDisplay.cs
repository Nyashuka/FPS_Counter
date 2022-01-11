using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FPSCounter))]
public class FPSDisplay : MonoBehaviour
{
    [SerializeField] private Text _label;

    private FPSCounter _fpsCounter;

    private void Awake()
    {
        _fpsCounter = GetComponent<FPSCounter>();
    }

    private void Update()
    {
        _label.text = _fpsCounter.FPS.ToString();
    }
}
