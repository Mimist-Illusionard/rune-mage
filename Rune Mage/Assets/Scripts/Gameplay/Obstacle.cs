using UnityEngine;
using UnityEngine.Events;


public class Obstacle : MonoBehaviour, ILifeTime, IInitialize
{
    public float LifeTime { get; set; }

    public UnityEvent OnInitialize;

    public void Initialize()
    {
        Destroy(gameObject, LifeTime);
        OnInitialize?.Invoke();
    }
}
