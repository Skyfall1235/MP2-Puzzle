using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    //the main menu should basically be a start and quit button
    [SerializeField] private string SceneName;

    public void LaunchGame()
    {
        LaunchScene(SceneName);
    }
    public void NextLevel()
    {
        int sceneInt = SceneManager.GetActiveScene().buildIndex + 1;
        LaunchScene(sceneInt);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private void LaunchScene(string sceneName)
    {
        Debug.Log($"Loading scene {SceneName}");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    private void LaunchScene(int sceneInt)
    {
        Debug.Log($"Loading scene {SceneName}");
        SceneManager.LoadScene(sceneInt, LoadSceneMode.Single);
    }
}
