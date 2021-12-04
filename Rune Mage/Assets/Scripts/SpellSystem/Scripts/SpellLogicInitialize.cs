using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;
using System.Collections;

public class SpellLogicInitialize : SerializedMonoBehaviour, ISpell
{
    [SerializeField] private List<ISpellLogic> _logics;

    public GameObject Prefab => gameObject;

    public bool IsLogicEnded { get; set; }

    private void Start()
    {
        SpellLogic();
    }

    public void SpellLogic()
    {
        IsLogicEnded = false;

        for (int i = 0; i < _logics.Count; i++)
        {
            var spellLogic = _logics[i];
            spellLogic.Initialize();
        }

        CoroutineManager.Singleton.RunCoroutine(Logic(gameObject));
    }

    private IEnumerator Logic(GameObject spell)
    {
        int spellCount = _logics.Count;
        int currentSpellCount = 0;

        var nextSpellLogic = _logics[currentSpellCount];

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
                nextSpellLogic = _logics[currentSpellCount];
                CoroutineManager.Singleton.RunCoroutine(nextSpellLogic.Logic(spell, this));
            }
        }

        if (spell) spell.GetComponent<IInitialize>().Initialize();
        IsLogicEnded = false;
    }
}
