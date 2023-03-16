using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject characterSelectionPanel;
    [SerializeField] private GameObject winAndLossPanel;

    [SerializeField] private GameObject resumeButton;

    public bool isMainMenuOpen;

    private void Start()
    {
        GameMenu();
    }

    public void PlayGame()
    {
        CloseAllPanels();
        characterSelectionPanel.SetActive(true);
    }

    public void StartGame()
    {
        characterSelectionPanel.SetActive(false);
        GameManager.INSTANCE.isGameStarted = true;
        resumeButton.SetActive(true);
        GameMenu();
    }

    public void HowtoPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    public void WinLossPanel()
    {
        CloseAllPanels();
        winAndLossPanel.SetActive(true);
    }

    public void RestartGame()
    {
        resumeButton.SetActive(false);
        GameManager.INSTANCE.isGameStarted= false;
        CloseAllPanels();
        GameMenu();
    }

    public void GameMenu()
    {
        isMainMenuOpen = !isMainMenuOpen;
        mainMenuPanel.SetActive(isMainMenuOpen);
        PauseGame(isMainMenuOpen);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void CloseAllPanels()
    {
        howToPlayPanel.SetActive(false);
        characterSelectionPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        winAndLossPanel.SetActive(false);
    }


    private void PauseGame(bool value)
    {
        if (value) {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }
}
