using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : Quest
{
    public float Dst;

    public override void ExitToMain(SimpleQ i)
    {
        if(Dst > 0)
        {
            if (gameObject.GetComponent<EnemyMain>().TargetDistance <= Dst)
            {
                i.tt = true;
                i.ExitToMain();
            }
            else
            {
                i.tt = false;
                i.ExitToMain();
            }
        }
        else
        {
            if (gameObject.GetComponent<EnemyMain>().TargetDistance <= gameObject.GetComponent<EnemyData>().AttackRadius)
            {
                i.tt = true;
                i.ExitToMain();
            }
            else
            {
                i.tt = false;
                i.ExitToMain();
            }
        }
        
    }

    public override void PlayQuest(SimpleQ i)
    {
        ExitToMain(i);
    }
}
