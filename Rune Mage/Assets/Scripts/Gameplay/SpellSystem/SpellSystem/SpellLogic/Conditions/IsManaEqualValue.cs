using UnityEngine;

public class IsManaEqualValue : ICondition
{
    public float Value;
    public EqualType EqualType;

    public bool Condition()
    {
        var mana = PlayerManager.Singleton.GetMana().GetCurrentMana();

        switch (EqualType)
        {
            case EqualType.None:
                Debug.LogError($"Not setted EqualType in {this}");
                return false;

            case EqualType.Equal:
                return mana == Value;

            case EqualType.Less:
                return mana < Value;

            case EqualType.Greater:
                return mana > Value;

            default:
                Debug.LogError($"Not setted EqualType in {this}");
                return false;
        }
    }
}