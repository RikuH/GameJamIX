using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHUD : MonoBehaviour
{
    public Button StartGameButton;
    public Button BackToMenuButton;

    public GameObject GameOverPanel;
    void GameOver()
    {   
        GameOverPanel.SetActive(true);
    }

    void BackToMenu()
    {
        
        SceneManager.LoadScene("TaritanScene");
    }
    void Start()
    {
        BackToMenuButton.onClick.AddListener(BackToMenu);
        StartGameButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

}
