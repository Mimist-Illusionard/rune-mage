using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class ChainLogic : ISpellLogic, ISpell
{
    [SerializeField] private List<ISpellLogic> _spellLogics = new List<ISpellLogic>();

    public LogicType LogicType { get; set; }

    private GameObject _prefab;
    public GameObject Prefab => _prefab;
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

    public IEnumerator Logic(GameObject spell, ISpell iSpell)
    {
        Debug.Log("Chain logic");
        _prefab = iSpell.Prefab;
        var createdSpell = spell;

        int currentSpellCount = 0;

        var currentSpell = _spellLogics[currentSpellCount];
        CoroutineManager.Singleton.RunCoroutine(currentSpell.Logic(createdSpell, this));

        while (true)
        {
            yield return new WaitForEndOfFrame();

            if (IsLogicEnded)
            {
                currentSpellCount++;

                if (currentSpellCount == _spellLogics.Count)
                {
                    break;
                }

                currentSpell = _spellLogics[currentSpellCount];
                CoroutineManager.Singleton.RunCoroutine(currentSpell.Logic(createdSpell, this));
            }
        }

        if(createdSpell) createdSpell.GetComponent<IInitialize>().Initialize();
        IsLogicEnded = false;
        iSpell.IsLogicEnded = true;
    }
}
