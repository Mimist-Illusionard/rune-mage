using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeadAction : SerializedMonoBehaviour
{
    public List<ISpecialAction> actions = new List<ISpecialAction>();

    private void OnDestroy()
    {
        foreach (ISpecialAction action in actions)
        {
            action.StartAction(gameObject);
        }
    }
}
