using UnityEngine;

public enum GameState
{
    None,
    Init,
    MainMenu,
    GamePlay,
    Puased,
    options,
    GameOver

}
public class GameStateManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;

    public GameState currentState { get; private set; }

    public GameState previousState { get; private set; }

    [Header("Debug(read only)")]
    [SerializeField] string currentActiveState;
    [SerializeField] string previousActiveState;



    private void Start()
    {

        uiManager = ServiceHub.Instance.uIManager;
        SetState(GameState.Init);
    }

    public void SetState(GameState newState)
    {
        if (currentState == newState) return;
        previousState = currentState;
        currentState = newState;

        Debug.Log(previousState);
        Debug.Log(currentState);

        currentActiveState = currentState.ToString();
        
        previousActiveState = previousState.ToString();

        OnGameStateChanged(previousState, currentState);
    }

    private void OnGameStateChanged(GameState previousState, GameState newState)
    {
        switch (newState)
        {
            
            case GameState.None:
                Debug.Log("Huh");
                break;
            case GameState.Init:

                Debug.Log("GameState changed to Init");
                SetState(GameState.MainMenu);
                break;

            case GameState.MainMenu:

                Debug.Log("GameState changed to MainMenu");
                uiManager.ShowMenu();
                break;

            case GameState.GamePlay:

                Debug.Log("GameState changed to GamePlay");
                Time.timeScale = 1f;
                uiManager.ShowGamePlay();
                
                break;

            case GameState.Puased:

                Debug.Log("GameState changed to Paused");
                Time.timeScale = 0;
                uiManager.ShowPaused();
                
                break;

            case GameState.GameOver:
                uiManager.ShowGameOver();
                break;

            case GameState.options:
                uiManager.ShowOptions();
                break;

            default:
                break;
        }

    }

    public void StartGame()
    {
        SetState(GameState.GamePlay);
    }
    public void StartMenu()
    {
        SetState(GameState.MainMenu);
    }
    public void StartOptions()
    {
        SetState(GameState.options);
    }
    public void PreviousState()
    {
        SetState(previousState);

    }
    public void TogglePause()
    {
        if(currentState == GameState.Puased)
        {
            // resume game
            if (currentState == GameState.GamePlay) return;
            SetState(GameState.GamePlay);

        }
        else if (currentState == GameState.GamePlay) 
        {
            // pause
            if (currentState == GameState.Puased) return;
            SetState(GameState.Puased);
        }

        
    }
    public void Death()
    {
        if (currentState == GameState.GamePlay)
        {
            // resume game
            SetState(GameState.GameOver);

        }
        else return;


    }





}
