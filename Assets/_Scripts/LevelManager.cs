using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    static string sceneWaitingToLoad;

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel(string sceneName, float delayTime)
    {
        sceneWaitingToLoad = sceneName;
        Invoke("LoadWithDelay", delayTime);
    }

    public void LoadWithDelay()
    {
        SceneManager.LoadScene(sceneWaitingToLoad);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}