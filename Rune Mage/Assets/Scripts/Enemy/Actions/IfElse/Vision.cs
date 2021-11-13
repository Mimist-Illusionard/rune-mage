using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : Quest
{
    public override void ExitToMain(SimpleQ i)
    {
        i.tt = gameObject.GetComponentInObject<EnemyMain>().TargetVisible;
        i.ExitToMain();
    }

    public override void PlayQuest(SimpleQ i)
    {
        ExitToMain(i);
    }
}
