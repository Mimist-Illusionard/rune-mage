using UnityEngine;


public class DestroyObject : MonoBehaviour
{
    public bool Initialize;
    public void Start()
    {
        if (Initialize) Destroy();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
