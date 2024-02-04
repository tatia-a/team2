using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject PauseButton;
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("The single life form");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("theMenu");
    }
    public void Continue()
    {
        PauseButton.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }
}