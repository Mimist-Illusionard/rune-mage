using UnityEngine;


public class TransformChild : MonoBehaviour, IExecute
{
    public Transform Owner;
    public float DestroyTime;

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        if (Owner)
        {
            transform.position = Owner.position;
            transform.rotation = Owner.rotation;
        }
        else
        {
            Destroy(gameObject, DestroyTime);
        }
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}