using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject WinandLossPanel;

    public bool isGameStarted;
    public bool isMainMenuOpen;
  


    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else if (INSTANCE != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        OpenGameMenu();
    }

    public void OpenGameMenu()
    {
        mainMenuPanel.SetActive(true);
        isMainMenuOpen = true;
        resumeButton.SetActive(isGameStarted);
    }

    public void CloseGameMenu()
    {
        mainMenuPanel.SetActive(false);
        isMainMenuOpen = false;
        isGameStarted = true;
      
    }

    public void WinPanel()
    {
        WinandLossPanel.SetActive(true);
    }

    public void LossPanel()
    {
        WinandLossPanel.SetActive(false);
    }

    public void RestartGame()
    {
        mainMenuPanel.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameStarted)
            {
                Debug.Log("IS it running++");
                isMainMenuOpen = !isMainMenuOpen;

                if (isMainMenuOpen)
                {                                
                    OpenGameMenu();
                    Debug.Log("Open");
                }
                else
                {
                    CloseGameMenu();
                    Debug.Log("Close");
                }

                PauseGame(!isMainMenuOpen);
            }
        }
    }

    private static void PauseGame(bool value)
    {
        if (value)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }



}




