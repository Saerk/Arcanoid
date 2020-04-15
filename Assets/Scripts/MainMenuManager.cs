using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Login");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
