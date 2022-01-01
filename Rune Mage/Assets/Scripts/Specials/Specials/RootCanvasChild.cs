using UnityEngine;


public class RootCanvasChild : MonoBehaviour
{
    private void Start()
    {
        transform.parent = GameObject.FindObjectOfType<RootCanvas>().transform;
    }
}
