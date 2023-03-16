using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject howtoplayPanel;
    [SerializeField] private GameObject characterSelectionPanel;
    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        characterSelectionPanel.SetActive(true);
    }

    public void HowtoPlay()
    {
        howtoplayPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

  


}
