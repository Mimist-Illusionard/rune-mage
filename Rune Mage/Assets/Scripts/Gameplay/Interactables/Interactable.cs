using UnityEngine;
using UnityEngine.Events;


public abstract class Interactable : MonoBehaviour
{
    public UnityEvent OnEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        OnEnter(other);
        OnEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit(other);
    }

    protected abstract void OnEnter(Collider other);    
    protected abstract void OnExit(Collider other);    
}
