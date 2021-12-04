using UnityEngine;

using System;


public class RewardSpellSystem : MonoBehaviour
{
    [SerializeField] Transform _rewardSpawnpoint;
    [SerializeField] private SpellReward[] _spellsRewards;    

    public void RandomReward()
    {
        var spellReward = _spellsRewards[UnityEngine.Random.Range(0, _spellsRewards.Length)];

        var spell = spellReward.Spells[UnityEngine.Random.Range(0, spellReward.Spells.Length)];
        var prefab = spellReward.TomePrefab;

        var createdObject = Instantiate(prefab, _rewardSpawnpoint);
        createdObject.GetComponent<SpellTome>().SetSpell(spell);
    }
}

[Serializable]
public class SpellReward
{
    public GameObject TomePrefab;
    public Spell[] Spells;
}
