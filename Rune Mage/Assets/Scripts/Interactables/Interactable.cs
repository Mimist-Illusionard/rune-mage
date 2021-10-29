using UnityEngine;


public abstract class Interactable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Interact(other);
    }

    protected abstract void Interact(Collider other);    
}
