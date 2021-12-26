using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEnemy : ISpecialAction
{
    public float TimeStun;
    public void StartAction(GameObject @object)
    {
        @object.GetComponent<EnemyMain>().Stun(TimeStun);
    }
}
