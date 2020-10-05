using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseScreen;

    // Method for Resume button
    public void Resumegame()
    {
        PauseScreen.SetActive(false);
    }

    // Method for Restart button
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            PauseScreen.SetActive(!PauseScreen.activeSelf);
    }

    // Method for Menu button
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
