public class AllConditions : ICondition
{
    public ICondition[] Conditions;

    public bool Condition()
    {
        for (int i = 0; i < Conditions.Length; i++)
        {
            var condition = Conditions[i];

            if (!condition.Condition()) return false;
        }

        return true;
    }
}
