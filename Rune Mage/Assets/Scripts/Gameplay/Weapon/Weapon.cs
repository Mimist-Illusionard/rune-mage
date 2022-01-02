using System.Collections.Generic;
using System.Collections;

using Sirenix.OdinInspector;

using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Ruinum/Data/Weapon")]
public class Weapon : SerializedScriptableObject, ISpell
{
    public GameObject WeaponPrefab;
    public int Durability;

    public WeaponType Type;

    public GameObject SpellPrefab;
    public List<ISpellLogic> SpellLogics;

    public GameObject Prefab => SpellPrefab;
    public bool IsLogicEnded { get; set; }

    public void UseLogic() 
    {
        IsLogicEnded = false;

        var spell = Instantiate(Prefab);

        for (int i = 0; i < SpellLogics.Count; i++)
        {
            var spellLogic = SpellLogics[i];
            spellLogic.Initialize();
        }

        CoroutineManager.Singleton.RunCoroutine(Logic(spell));
    }

    private IEnumerator Logic(GameObject spell)
    {
        int spellCount = SpellLogics.Count;
        int currentSpellCount = 0;

        var nextSpellLogic = SpellLogics[currentSpellCount];

        CoroutineManager.Singleton.RunCoroutine(nextSpellLogic.Logic(spell, this));

        while (true)
        {
            if (nextSpellLogic.LogicType == LogicType.Durable)
            {
                yield return new WaitForEndOfFrame();
            }

            if (IsLogicEnded)
            {
                currentSpellCount++;

                if (currentSpellCount == spellCount)
                {
                    break;
                }

                IsLogicEnded = false;
                nextSpellLogic = SpellLogics[currentSpellCount];
                CoroutineManager.Singleton.RunCoroutine(nextSpellLogic.Logic(spell, this));
            }
        }

        if (spell) spell.GetComponent<IInitialize>().Initialize();
        IsLogicEnded = false;
    }
}

public enum WeaponType
{
    None    = 0,
    Sword   = 1,
    Spheres = 2
}
