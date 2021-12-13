using System.Collections;
using UnityEngine;


public class TimLess : IQuest
{
    public float time;

    public void ExitToMain(SimpleQ i)
    {
        if (!i.bject) return;
        i.tt = true;
        i.ExitToMain();
    }

    public void PlayQuest(SimpleQ i)
    {
        CoroutineManager.Singleton.RunCoroutine(tt(i));
    }

    private IEnumerator tt(SimpleQ i)
    {
        yield return new WaitForSeconds(time);
        ExitToMain(i);
    }
}
