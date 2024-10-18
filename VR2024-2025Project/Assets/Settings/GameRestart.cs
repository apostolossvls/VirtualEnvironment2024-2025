using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    //Called when object is enabled
    void OnEnable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void OnDisable()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //called by button press
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
