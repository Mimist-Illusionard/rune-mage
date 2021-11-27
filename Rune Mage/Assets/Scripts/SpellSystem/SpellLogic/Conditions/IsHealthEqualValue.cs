using UnityEngine;

public class IsHealthEqualValue : ICondition
{
    public float Value;
    public EqualType EqualType;

    public bool Condition()
    {
        var health = PlayerManager.Singleton.GetHealth().CurrentHealth;

        switch (EqualType)
        {
            case EqualType.None:
                Debug.LogError($"Not setted EqualType in {this}");
                return false;

            case EqualType.Equal:
                return health == Value;

            case EqualType.Less:
                return health < Value;

            case EqualType.Greater:
                return health > Value;

            default:
                Debug.LogError($"Not setted EqualType in {this}");
                return false;
        }
    }
}
