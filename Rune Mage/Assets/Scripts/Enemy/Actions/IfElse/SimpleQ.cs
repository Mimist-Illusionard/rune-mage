using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SimpleQ : IEnemyAction
{
    public Quest Quest;
    public MonoBehaviour Variant1;
    public MonoBehaviour Variant2;
    public bool tt;

    public GameObject bject { get; set; }


    public void ExitToMain()
    {
        if (tt)
        {
            var FSV = (IEnemyAction)Variant1;
            //FSV.PlayAction(bject);
        }
        else
        {
            var SSV = (IEnemyAction)Variant2;
            //SSV.PlayAction(bject,);
        }
    }

    public void PlayAction(GameObject @object)
    {
        bject = @object;
        Quest.PlayQuest(this);
    }


}
