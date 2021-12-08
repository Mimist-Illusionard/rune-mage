using UnityEngine.Events;
using UnityEngine;


public class EventOnStart : MonoBehaviour
{
    public UnityEvent UnityEvent;

    private void Start()
    {
        UnityEvent?.Invoke();
    }
}
