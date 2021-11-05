using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleQ : MonoBehaviour, IEnemyAction
{
    public Quest Quest;
    public MonoBehaviour Variant1;
    public MonoBehaviour Variant2;
    public bool tt;

    public void ExitToMain()
    {
        if (tt)
        {
            var FSV = (IEnemyAction)Variant1;
            FSV.PlayAction();
        }
        else
        {
            var SSV = (IEnemyAction)Variant2;
            SSV.PlayAction();
        }
    }

    public void PlayAction()
    {
        
        Quest.PlayQuest(this);
    }
}
