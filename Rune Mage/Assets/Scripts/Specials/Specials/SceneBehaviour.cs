using UnityEngine.SceneManagement;
using UnityEngine;



public class SceneBehaviour : MonoBehaviour
{
    private int _sceneId;

    public void UnloadActiveScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
  
    public void LoadSceneAddictive(int id)
    {
        Application.LoadLevelAdditive(id);
    }

    public void LoadScene(int id)
    {
        SceneManager.LoadSceneAsync(id);
    }

    public void LoadSceneForId()
    {
        SceneManager.LoadSceneAsync(_sceneId);
    }

    public void ChangeSceneId(int value)
    {
        _sceneId = value;
    }
}
