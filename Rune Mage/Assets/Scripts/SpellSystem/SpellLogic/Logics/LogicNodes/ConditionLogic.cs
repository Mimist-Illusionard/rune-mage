using System.Collections;

using UnityEngine;


public class ConditionLogic : ISpellLogic, ISpell
{
    public ICondition Condition;
    public ISpellLogic SpellLogic;
    public LogicType LogicType { get; set; }
    public bool IsLogicEnded { get; set; }

    private GameObject _prefab;
    public GameObject Prefab => _prefab;

    private CoroutineRunner _coroutineRunner;

    public void Initialize()
    {
        LogicType = LogicType.Durable;
        IsLogicEnded = false;

        SpellLogic.Initialize();
    }

    public IEnumerator Logic(GameObject spell, ISpell iSpell)
    {
        IsLogicEnded = true;
        _prefab = iSpell.Prefab;     

        while (true)
        {
            yield return new WaitForEndOfFrame();

            if (Condition.Condition())
            {
                Debug.Log("Conditions = true");
                Debug.Log(IsLogicEnded);
                if (IsLogicEnded)
                {
                    if(_coroutineRunner) _coroutineRunner.StopAllCorotines();
                    _coroutineRunner = null;

                    var createdSpell = Object.Instantiate(_prefab);                 
                    _coroutineRunner = CoroutineManager.Singleton.RunCoroutine(SpellLogic.Logic(createdSpell, this));
                    IsLogicEnded = false;
                }
            }
            else
            {
                break;
            }
        }

        IsLogicEnded = false;
        iSpell.IsLogicEnded = true;

        if(_coroutineRunner) _coroutineRunner.StopAllCorotines();
        _coroutineRunner = null;
    }
}