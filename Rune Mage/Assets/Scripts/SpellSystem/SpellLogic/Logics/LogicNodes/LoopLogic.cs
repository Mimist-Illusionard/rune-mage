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

    private GameObject _prefab;
    public GameObject Prefab => _prefab;

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
        _prefab = ISpell.Prefab;

        for (int i = 0; i < LoopAmount;)
        {
            var createdSpell = spell;

            if (i >= 1) createdSpell = Object.Instantiate(_prefab);
            int spellCount = _spellLogics.Count;
            int currentSpellCount = 0;

            var spellLogics = new ISpellLogic[_spellLogics.Count];
            _spellLogics.CopyTo(spellLogics);

            var currentSpell = spellLogics[currentSpellCount];
            CoroutineManager.Singleton.RunCoroutine(currentSpell.Logic(createdSpell, this));

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

                    currentSpell = spellLogics[currentSpellCount];
                    CoroutineManager.Singleton.RunCoroutine(currentSpell.Logic(createdSpell, this));
                }
            }

            createdSpell.GetComponent<IInitialize>().Initialize();
            IsLogicEnded = false;
            i++;
        }

        ISpell.IsLogicEnded = true;
    }
}
