using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DamageActions : SerializedMonoBehaviour
{
    public List<ISpecialAction> actions = new List<ISpecialAction>();

    private void Start()
    {
        gameObject.GetComponent<Health>().OnHealthChange += PlayActions;
    }

    private void PlayActions(float Current, float Max)
    {
        foreach (ISpecialAction action in actions)
        {
            action.StartAction(gameObject);
        }
    }
}
