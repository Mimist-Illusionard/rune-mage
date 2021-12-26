using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayerLerp : MonoBehaviour, IExecute
{

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
