using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject howtoplayPanel;
    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
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
