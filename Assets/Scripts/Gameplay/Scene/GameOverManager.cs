using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainMenuButton;

    private void OnEnable()
    {
        retryButton.onClick.AddListener(Retry);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void OnDisable()
    {
        retryButton.onClick.RemoveListener(Retry);
        mainMenuButton.onClick.RemoveListener(LoadMainMenu);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}