using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public PlayerInput playerInput;
    bool isPaused;

    bool wasCursorVisible;
    CursorLockMode previousLockState;
    float previousTimeScale;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPaused = false;
        pauseScreen.SetActive(isPaused);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;

        pauseScreen.SetActive(true);

        previousLockState = Cursor.lockState;
        wasCursorVisible = Cursor.visible;
        previousTimeScale = Time.timeScale;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        playerInput.enabled = false;
    }

    public void Resume()
    {
        isPaused = false;

        pauseScreen.SetActive(false);

        Cursor.lockState = previousLockState;
        Cursor.visible = wasCursorVisible;
        Time.timeScale = previousTimeScale;

        playerInput.enabled = true;
    }

    public void QuitApp()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
