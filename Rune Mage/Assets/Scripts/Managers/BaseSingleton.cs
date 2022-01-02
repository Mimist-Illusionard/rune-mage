using UnityEngine;


public class BaseSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Singleton { get; private set; }
    protected virtual void Awake() => Singleton = this as T;
}
