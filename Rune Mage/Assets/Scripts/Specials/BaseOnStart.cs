using UnityEngine;


public abstract class BaseOnStart : MonoBehaviour
{
    [SerializeField] private bool OnStart = true;

    public virtual void Start()
    {
        if (OnStart) Logic();
    }

    public abstract void Logic();
}
