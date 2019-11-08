using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button StartGameButton;
    public Button CreditsButton;
    public Button ExitButton;
    public Button BackButton;

    public GameObject MainPanel;
    public GameObject CreditsPanel;

    

    void StartGame()
    {   
        MainPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("SULKEE");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGameButton.onClick.AddListener(StartGame);
        CreditsButton.onClick.AddListener(CreditPanel);
        ExitButton.onClick.AddListener(QuitGame);
        BackButton.onClick.AddListener(BackButtonToMain);
    }

    void CreditPanel()
    {
        CreditsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    void BackButtonToMain()
    {
        MainPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

}
