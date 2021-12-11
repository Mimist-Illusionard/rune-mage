using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSystem : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {
        if (scene.name == "Menu")
        {
            var destroyObjects = GameObject.FindObjectsOfType<DestroyOnSpecialScenes>();

            foreach (var destroyObject in destroyObjects)
            {
                Destroy(destroyObject.gameObject);
            }
        }
    }
}
