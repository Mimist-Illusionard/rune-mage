using UnityEngine;


public class DestroyIsHasPlayer : MonoBehaviour
{
    private void Start()
    {
        if (GameObject.FindObjectsOfType<Player>().Length >= 2)
        {
            Destroy(gameObject);
        }
    }
}
