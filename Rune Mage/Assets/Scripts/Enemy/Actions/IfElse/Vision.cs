

public class Vision : IQuest
{
    public void ExitToMain(SimpleQ i)
    {
        if (!i.bject) return;
        i.tt = i.bject.GetComponentInObject<EnemyMain>().TargetVisible;
        i.ExitToMain();
    }

    public void PlayQuest(SimpleQ i)
    {
        ExitToMain(i);
    }
}
