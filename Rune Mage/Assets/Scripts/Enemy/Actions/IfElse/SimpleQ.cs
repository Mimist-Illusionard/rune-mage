using UnityEngine;


public class SimpleQ : IEnemyAction
{
    public IQuest Quest;
    public IEnemyAction True;
    public IEnemyAction False;
    [HideInInspector] public bool tt;
    private IEnemyAction _parent;
    public GameObject bject { get; set; }

    public void ExitToMain()
    {
        if (tt)
        {
            True.PlayAction(bject, _parent);
        }
        else
        {
            False.PlayAction(bject, _parent);
        }
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        _parent = _Parent;
        bject = @object;
        Quest.PlayQuest(this);
    }
}
