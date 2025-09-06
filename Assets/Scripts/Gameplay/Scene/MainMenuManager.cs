using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        startButton.onClick.AddListener(Play);
        exitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(Play);
        exitButton.onClick.RemoveListener(Exit);
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Exit()
    {
        Application.Quit();
    }
}