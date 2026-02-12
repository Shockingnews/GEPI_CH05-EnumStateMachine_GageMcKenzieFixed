using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject gamePlayUI;
    [SerializeField] GameObject pausedUI;
    [SerializeField] GameObject optionsUI;
    [SerializeField] GameObject gameOverUI;



    public void ShowMenu()
    {
        HideAllUI();

        mainMenuUI.SetActive(true);
    }
    public void ShowGamePlay()
    {
        HideAllUI();
        gamePlayUI.SetActive(true);
    }
    public void ShowPaused()
    {
        HideAllUI();
        gamePlayUI.SetActive(true);
        pausedUI.SetActive(true);
    }

    public void ShowGameOver()
    {
        HideAllUI();
        gameOverUI.SetActive(true);
    }

    public void ShowOptions()
    {
        HideAllUI();
        optionsUI.SetActive(true);
    }

    public void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        pausedUI.SetActive(false);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(false);
        gameOverUI.SetActive(false);
    }
}
