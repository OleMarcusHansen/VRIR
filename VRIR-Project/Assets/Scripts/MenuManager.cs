using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputActionReference menuAction;

    bool menuOpen;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject resultsMenu;

    void Start()
    {
        ToggleMainMenu(true);
    }

    public void ToggleMainMenu(bool b)
    {
        mainMenu.SetActive(b);
        menuOpen = b;
    }
    public void ToggleResultsMenu(bool b)
    {
        resultsMenu.SetActive(b);
    }

    void ToggleMenu(InputAction.CallbackContext context)
    {
        ToggleMainMenu(!menuOpen);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void OnEnable()
    {
        if (menuAction != null && menuAction.action != null)
        {
            menuAction.action.Enable();
            menuAction.action.performed += ToggleMenu;
        }
    }

    void OnDisable()
    {
        if (menuAction != null && menuAction.action != null)
        {
            menuAction.action.performed -= ToggleMenu;
            menuAction.action.Disable();
        }
    }
}
