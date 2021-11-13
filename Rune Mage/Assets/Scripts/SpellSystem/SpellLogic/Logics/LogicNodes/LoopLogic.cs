using System.Collections.Generic;
using System.Collections;

using UnityEngine;


public class LoopLogic : ISpellLogic, ISpell
{
    [SerializeField] private List<ISpellLogic> _spellLogics = new List<ISpellLogic>();
    [SerializeField] private float LoopAmount;

    private GameObject _spell;

    public LogicType LogicType { get; set; }
    public bool IsLogicEnded { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Durable;

        for (int i = 0; i < _spellLogics.Count; i++)
        {
            var spellLogic = _spellLogics[i];
            spellLogic.Initialize();
        }
    }

    public IEnumerator Logic(GameObject spell, ISpell ISpell)
    {
        _spell = Object.Instantiate(spell);

        for (int i = 0; i < LoopAmount; i++)
        {
            var createdSpell = Object.Instantiate(_spell);
            int spellCount = _spellLogics.Count;
            int currentSpellCount = 0;

            var currentSpell = _spellLogics[currentSpellCount];

            SpellLogic(currentSpell, createdSpell, currentSpellCount);

            while (true)
            {
                yield return new WaitForEndOfFrame();

                if (IsLogicEnded)
                {
                    currentSpellCount++;

                    if (currentSpellCount == spellCount)
                    {
                        break;
                    }

                    currentSpell = _spellLogics[currentSpellCount];
                    SpellLogic(currentSpell, createdSpell, currentSpellCount);
                }
            }

            createdSpell.GetComponent<IInitialize>().Initialize();
        }

        ISpell.IsLogicEnded = true;
    }

    private void SpellLogic(ISpellLogic currentSpell, GameObject spell, int currentSpellCount)
    {
        if (currentSpell.GetType() == typeof(PrefabLogic)) //Stupid resolve :/
        {
            var prefabSpellLogic = (PrefabLogic)currentSpell;
            prefabSpellLogic.CreateSpell(out spell);

            CoroutineManager.Singleton.RunCoroutine(currentSpell.Logic(spell, this));
        }
        else
        {
           CoroutineManager.Singleton.RunCoroutine(_spellLogics[currentSpellCount].Logic(spell, this));
        }
    }
}
