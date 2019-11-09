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
    public GameObject VictoryPanel;
    void Update()
    {

        if (GameObject.Find("RealLonk").GetComponent<PlayerMovement>().health <= 0)
        {
            GameOverPanel.SetActive(true);
        }

    }

    public void BackToMenu()
    {
        Debug.Log("W");
        SceneManager.LoadScene("TaritanScene");
    }
    void Start()
    {
        BackToMenuButton.onClick.AddListener(BackToMenu);
        StartGameButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        GameOverPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

    public void voitto()
    {
        //Jos room on victoryRoom
        VictoryPanel.SetActive(true);
        Debug.Log("sd");
        BackToMenuButton.onClick.AddListener(BackToMenu);
        StartGameButton.onClick.AddListener(StartGame);

    }

}
