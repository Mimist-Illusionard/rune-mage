using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimLess : Quest
{
    public float time;

    public override void ExitToMain(SimpleQ i)
    {
        i.tt = true;
        i.ExitToMain();
    }

    public override void PlayQuest(SimpleQ i)
    {
        StartCoroutine(tt(i));
    }

    IEnumerator tt(SimpleQ i)
    {
        yield return new WaitForSeconds(time);
        ExitToMain(i);
    }
}
