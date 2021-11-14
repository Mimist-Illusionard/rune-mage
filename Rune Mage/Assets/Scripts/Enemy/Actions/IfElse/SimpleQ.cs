using UnityEngine;


public class SimpleQ : IEnemyAction
{
    public IQuest Quest;
    public IEnemyAction True;
    public IEnemyAction False;
    [HideInInspector] public bool tt;

    public GameObject bject { get; set; }

    public void ExitToMain()
    {
        if (tt)
        {
            True.PlayAction(bject);
        }
        else
        {
            False.PlayAction(bject);
        }
    }

    public void PlayAction(GameObject @object)
    {
        bject = @object;
        Quest.PlayQuest(this);
    }
}
