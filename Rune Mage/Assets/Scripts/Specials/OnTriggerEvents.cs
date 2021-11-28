using UnityEngine;
using UnityEngine.Events;


public class OnTriggerEvents : MonoBehaviour
{
    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerEnterExit;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerEnterExit?.Invoke(); 
    }
}
