

public class Distance : IQuest
{
    public float Dst;

    public void ExitToMain(SimpleQ i)
    {
        if (!i.bject) return;
        if (Dst > 0)
        {
            if (i.bject.GetComponent<EnemyMain>().TargetDistance <= Dst)
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
            if (i.bject.GetComponent<EnemyMain>().TargetDistance <= i.bject.GetComponent<EnemyData>().AttackRadius)
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

    public void PlayQuest(SimpleQ i)
    {
        ExitToMain(i);
    }
}
