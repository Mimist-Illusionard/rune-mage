using UnityEngine;

using DG.Tweening;


public class SpellChoser : MonoBehaviour
{
    [SerializeField] private HintRunes _hintRunes;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private SpellData[] _spellDatas;

    private GameObject _createdObject;
    private int _index;

    public void IncreaseIndex()
    {
        _index++;
        SpawnSpellPrefab();
    }

    public void DecreaseIndex()
    {
        _index--;
    }

    public void UpdateSpells()
    {
        var knowedSpells = SpellsSystem.Singleton.GetSpells();

        for (int i = 0; i < knowedSpells.Count; i++)
        {
            var knowedSpell = knowedSpells[i];
            for (int j = 0; j < _spellDatas.Length; j++)
            {
                var spellData = _spellDatas[j];
                if (spellData.Spell == knowedSpell)
                {
                    spellData.IsKnown = true;
                }
            }
        }
    }

    private void DoMoveZ(GameObject gameObject)
    {
        gameObject.transform.DOMoveZ(gameObject.transform.position.z + 0.1f, 0.1f).OnComplete(() 
            => gameObject.transform.DOMoveZ(gameObject.transform.position.z - 0.2f, 0.1f).OnComplete(() 
            => gameObject.transform.DOMoveZ(gameObject.transform.position.z + 0.1f, 0.1f))).OnComplete(() => DoMoveZ(gameObject));
    }

    private void SpawnSpellPrefab()
    {
        var spellData = _spellDatas[_index];

        if (!spellData.IsKnown) return;

        Destroy(_createdObject);

        _createdObject = Instantiate(spellData.Prefab, _spawnpoint);
        _hintRunes.SetHintRunes(spellData.Spell);

        DoMoveZ(_createdObject);
    }
}