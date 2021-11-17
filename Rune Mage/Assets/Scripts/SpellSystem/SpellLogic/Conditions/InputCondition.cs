using UnityEngine;


public class InputCondition : ICondition
{
    public KeyCode Key;

    public bool Condition()
    {
        return Input.GetKey(Key);
    }
}
