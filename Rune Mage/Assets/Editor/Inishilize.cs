using UnityEditor;

[System.Serializable]
public class Initialize
{

    [MenuItem("Ruinum/Initialize")]
    public static void Play()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Initialize.unity");
        EditorApplication.isPlaying = true;
    }
}
