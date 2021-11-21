using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeadAction : SerializedMonoBehaviour
{
    public List<IDeadAction> actions = new List<IDeadAction>();

    private void OnDestroy()
    {
        foreach (IDeadAction action in actions)
        {
            action.StartAction(gameObject);
        }
    }
}
