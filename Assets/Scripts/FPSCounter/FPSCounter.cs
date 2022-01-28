using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private int _frameRange = 60;

    private int _fpsRangeCounter;

    private int _fpsSum = 0;

    public int FPS { get; private set; }

    void Update()
    {
        if(_fpsRangeCounter <= _frameRange)
        {
            _fpsSum += (int)(1f / Time.unscaledDeltaTime);
            _fpsRangeCounter++;
        }
        else
        {
            FPS = _fpsSum / _frameRange;
            _fpsSum = 0;
            _fpsRangeCounter = 0;
        }
    }
}
