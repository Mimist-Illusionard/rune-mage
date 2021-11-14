using UnityEngine;

public interface ISpell
{
    public GameObject Prefab { get; }
    public bool IsLogicEnded { get; set; }
}