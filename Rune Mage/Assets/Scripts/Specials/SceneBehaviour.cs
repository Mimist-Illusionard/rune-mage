using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneBehaviour : MonoBehaviour
{

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
}
