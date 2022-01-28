using UnityEngine;

public class KeyboardHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _inventory;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            _inventory.SetActive(!_inventory.active);
        }
    }

    private void SetPause()
    {
        if(_pauseMenuPanel.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        _pauseMenuPanel.SetActive(!_pauseMenuPanel.activeSelf);

        if (Time.timeScale == 0)
            Time.timeScale = 1f;
        else
            Time.timeScale = 0;
    }
}
