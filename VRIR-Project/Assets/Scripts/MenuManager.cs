using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputActionReference menuAction;
    [SerializeField] GameObject leftInteractor;
    [SerializeField] GameObject rightInteractor;
    [SerializeField] ControllerInputActionManager leftController;
    [SerializeField] ControllerInputActionManager rightController;

    bool menuOpen;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject resultsMenu;

    void Start()
    {
        //ToggleMainMenu(true);
        //ToggleControllers(false);
    }

    public void ToggleMainMenu(bool b)
    {
        mainMenu.SetActive(b);
        ToggleControllers(!b);
        menuOpen = b;
    }
    public void ToggleResultsMenu(bool b)
    {
        resultsMenu.SetActive(b);
    }

    void ToggleControllers(bool b)
    {
        if (b)
        {
            leftInteractor.SetActive(true);
            rightInteractor.SetActive(true);

            leftController.enabled = true;
            rightController.enabled = true;
        }
        else
        {
            leftInteractor.SetActive(false);
            rightInteractor.SetActive(false);

            leftController.enabled = false;
            rightController.enabled = false;
        }
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
