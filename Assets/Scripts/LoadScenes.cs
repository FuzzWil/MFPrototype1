using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadSceneTitle()
    {
        // Load the scene named "TitleScene", SceneManager will handle the loading process
        SceneManager.LoadScene("TitleScene");
    }

    public void LoadSceneInfo()
    {
        // Load the scene named "InfoScene", SceneManager will handle the loading process
        SceneManager.LoadScene("InfoScene");
    }

    public void LoadSceneTest()
    {
        // Load the scene named "TestScene", SceneManager will handle the loading process
        SceneManager.LoadScene("TestScene");
        Time.timeScale = 1f; // Ensure the game runs at normal speed when the scene is loaded
    }
}
