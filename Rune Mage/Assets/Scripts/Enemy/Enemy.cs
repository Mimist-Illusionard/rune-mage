using UnityEngine;


public class Enemy : MonoBehaviour, IExecute
{  
    private void Start()
    {
        GameManager.Singleton.SetNewExecuteObject(this);
    }

    public void Execute()
    {

    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
