using UnityEngine;


public class DestroyIfTutorialTaken : MonoBehaviour
{
    private void Start()
    {
        if (GameObject.FindObjectOfType<TutorialTaken>())
        {
            Destroy(gameObject);
        }

        Destroy(this);
    }
}
