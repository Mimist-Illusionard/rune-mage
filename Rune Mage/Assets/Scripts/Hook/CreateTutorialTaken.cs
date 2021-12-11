using UnityEngine;


public class CreateTutorialTaken : MonoBehaviour
{
    public void TutorialTaken()
    {
        var createdObject = new GameObject("TutorialTaken");
        createdObject.AddComponent<TutorialTaken>();
        DontDestroyOnLoad(createdObject);
    }
}
