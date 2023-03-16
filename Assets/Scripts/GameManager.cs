using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;

    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private UIManager _uiManager;

    public static MainMenu mainMenu { get; private set; }
    public static UIManager uIManager { get; private set; }

    public bool isGameStarted;

    private void Awake()
    {
        if (INSTANCE == null) {
            INSTANCE = this;
        }
        else if (INSTANCE != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        mainMenu = _mainMenu;
        uIManager = _uiManager;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (isGameStarted) {

                mainMenu.GameMenu();
            }
        }
    }
}




