using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PhaseActions : SerializedMonoBehaviour
{
    public float NextPhaseHP;

    public List<ISpecialAction> actions = new List<ISpecialAction>();

    private void Start()
    {
        gameObject.GetComponent<Health>().OnHealthChange += PlayActions;
    }

    private void PlayActions(float Current, float Max)
    {
        if (Current <= NextPhaseHP)
        {
            foreach (ISpecialAction action in actions)
            {
                action.StartAction(gameObject);
            }
            Destroy(this);
        }
    }
}
