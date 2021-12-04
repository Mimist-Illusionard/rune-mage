using UnityEngine;



public class DestroyOnInitialize : MonoBehaviour, IInitialize
{
    public void Initialize()
    {
        Destroy(gameObject);
    }
}
