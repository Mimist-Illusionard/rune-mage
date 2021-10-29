using UnityEngine;


public abstract class Interactable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OnEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit(other);
    }

    protected abstract void OnEnter(Collider other);    
    protected abstract void OnExit(Collider other);    
}
