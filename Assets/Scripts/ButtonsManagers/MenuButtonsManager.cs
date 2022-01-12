using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsManager : MonoBehaviour
{
    public void ShowObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void HideObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void LoadScene(int sceneIndex)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
