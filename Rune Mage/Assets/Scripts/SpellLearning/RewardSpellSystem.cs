using UnityEngine;

using System.Collections.Generic;
using System;

public class RewardSpellSystem : MonoBehaviour
{
    [SerializeField] Transform _rewardSpawnpoint;
    [SerializeField] private SpellReward[] _spellsRewards;    

    public void RandomReward()
    {
        var spellReward = _spellsRewards[UnityEngine.Random.Range(0, _spellsRewards.Length)];

        var allSpells = SpellsSystem.Singleton.GetSpells();

        for (int i = 0; i < spellReward.Spells.Count; i++)
        {
            var spell = spellReward.Spells[i];

            foreach (var knowedSpell in allSpells)
            {
                if (knowedSpell == spell)
                {
                    spellReward.Spells.Remove(spell);
                }
            }
        }

        if (spellReward.Spells.Count <= 0) Instantiate(spellReward.TomePrefab, _rewardSpawnpoint);
        else
        {
            var randomInt = UnityEngine.Random.Range(0, spellReward.Spells.Count);
            var rewardSpell = spellReward.Spells[randomInt];

            var createdObject = Instantiate(spellReward.TomePrefab, _rewardSpawnpoint);
            createdObject.GetComponent<SpellTome>().SetSpell(rewardSpell);
        }
    }
}

[Serializable]
public class SpellReward
{
    public GameObject TomePrefab;
    public List<Spell> Spells;
}
