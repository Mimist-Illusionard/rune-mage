using UnityEngine;


public class RootCanvas : MonoBehaviour
{
    public static RootCanvas Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }
}
