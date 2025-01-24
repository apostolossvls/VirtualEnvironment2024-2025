using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject menuCamera;

    public void StartApp()
    {
        player.SetActive(true);
        menuCamera.SetActive(false);
        gameObject.SetActive(false); //disable menu
    }

    public void QuitApp()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
