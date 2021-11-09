using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;


public class LoopLogic : ISpellLogic
{
    [SerializeField] private List<ISpellLogic> _spellLogics = new List<ISpellLogic>();
    [SerializeField] private float LoopAmount;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Durable;
    }    

    public async Task Logic(GameObject spell)
    {
        Debug.Log("LoopNodeLogic");

        for (int i = 0; i < LoopAmount; i++)
        {
            int spellCount = _spellLogics.Count;
            int currentSpellCount = 0;

            var spellNodeLogic = _spellLogics[currentSpellCount];
            var spellLogic = _spellLogics[currentSpellCount].Logic(spell);

            while (true)
            {
                if (spellLogic.IsCompleted)
                {
                    currentSpellCount++;

                    if (currentSpellCount == spellCount)
                    {                        
                        break;
                    }

                    spellNodeLogic = _spellLogics[currentSpellCount];
                    if (spellNodeLogic.GetType() == typeof(PrefabLogic)) //Stupid resolve :/
                    {
                        var prefabSpellLogic = (PrefabLogic)spellNodeLogic;
                        prefabSpellLogic.CreateSpell(out spell);

                        spellLogic = spellNodeLogic.Logic(spell);
                    }
                    else
                    {
                        spellLogic = _spellLogics[currentSpellCount].Logic(spell);
                    }
                }
            }

            spell.GetComponent<IInitialize>().Initialize();
        }

        return;
    }
}
