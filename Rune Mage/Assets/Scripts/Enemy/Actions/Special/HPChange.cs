using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class HPChange :  SerializedMonoBehaviour
{
    public List<DeadAction> actions = new List<DeadAction>();

    public void PlayActions()
    {
        foreach (ISpecialAction action in actions)
        {
            action.StartAction(gameObject);
        }
    }
}
