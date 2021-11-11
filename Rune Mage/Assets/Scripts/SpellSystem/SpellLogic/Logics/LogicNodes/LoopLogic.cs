using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;


public class LoopLogic : ISpellLogic
{
    [SerializeField] private List<ISpellLogic> _spellLogics = new List<ISpellLogic>();
    [SerializeField] private float LoopAmount;

    private GameObject _spell;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Durable;
    }    

    public async Task Logic(GameObject spell)
    {
        _spell = spell;

        for (int i = 0; i < LoopAmount; i++)
        {
            Debug.Log("test");

            int spellCount = _spellLogics.Count;
            int currentSpellCount = 0;

            var currentSpell = _spellLogics[currentSpellCount];

            SpellLogic(currentSpell, _spell, currentSpellCount, out var currentSpellLogic);

            while (true)
            {
                await Task.Yield();

                if (currentSpellLogic.IsCompleted)
                {
                    currentSpellCount++;

                    if (currentSpellCount == spellCount)
                    {
                        break;
                    }

                    currentSpell = _spellLogics[currentSpellCount];
                    SpellLogic(currentSpell, _spell, currentSpellCount, out currentSpellLogic);
                }
            }

            spell.GetComponent<IInitialize>().Initialize();
        }

        return;
    }

    private void SpellLogic(ISpellLogic currentSpell, GameObject spell, int currentSpellCount , out Task currentSpellLogic)
    {
        if (currentSpell.GetType() == typeof(PrefabLogic)) //Stupid resolve :/
        {
            var prefabSpellLogic = (PrefabLogic)currentSpell;
            prefabSpellLogic.CreateSpell(out spell);

            currentSpellLogic = currentSpell.Logic(spell);
        }
        else
        {
            currentSpellLogic = _spellLogics[currentSpellCount].Logic(spell);
        }
    }
}
