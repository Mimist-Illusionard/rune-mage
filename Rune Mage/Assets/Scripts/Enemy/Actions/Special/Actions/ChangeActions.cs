using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ChangeActions : ISpecialAction
{
    public List<IEnemyAction> actions = new List<IEnemyAction>();

    public void StartAction(GameObject @object)
    {
        @object.GetComponent<EnemyMain>().enemyActions.AddRange(actions);
    }
}
