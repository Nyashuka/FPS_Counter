using UnityEngine;

public class KeyboardHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuPanel;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }

    private void SetPause()
    {
        Cursor.lockState = CursorLockMode.None;

        _pauseMenuPanel.SetActive(!_pauseMenuPanel.activeSelf);

        if (Time.timeScale == 0)
            Time.timeScale = 1f;
        else
            Time.timeScale = 0;
    }
}
