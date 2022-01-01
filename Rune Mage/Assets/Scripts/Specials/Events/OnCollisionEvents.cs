using UnityEngine;
using UnityEngine.Events;


public class OnCollisionEvents : MonoBehaviour
{
    public UnityEvent OnCollisionEnterEvent;
    public UnityEvent OnCollisionEnterExit;

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionEnterEvent?.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        OnCollisionEnterExit?.Invoke();
    }
}
