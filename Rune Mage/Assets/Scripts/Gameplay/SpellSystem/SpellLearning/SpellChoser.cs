using UnityEngine;

using DG.Tweening;
using System.Collections.Generic;


public class SpellChoser : MonoBehaviour
{
    [SerializeField] private HintRunes _hintRunes;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private List<SpellData> _spellDatas;

    private GameObject _createdObject;
    private List<SpellData> _knowedSpells;
    private int _index;

    private void Start()
    {
        var allSpellDatas = new List<SpellData>();

        foreach (var spellData in _spellDatas)
        {
            var createdSpellData = Instantiate(spellData);
            allSpellDatas.Add(createdSpellData);
        }

        _spellDatas = allSpellDatas;
        _knowedSpells = new List<SpellData>();
    }

    public void IncreaseIndex()
    {
        if (_index + 1 >= _knowedSpells.Count) return;

        _index++;
        SpawnSpellPrefab();
    }

    public void DecreaseIndex()
    {
        if (_index - 1 <= 0) return;

        _index--;
        SpawnSpellPrefab();
    }

    public void UpdateSpells()
    {
        _knowedSpells.Clear();

        var knowedSpells = SpellsSystem.Singleton.GetSpells();

        for (int i = 0; i < knowedSpells.Count; i++)
        {
            var knowedSpell = knowedSpells[i];
            for (int j = 0; j < _spellDatas.Count; j++)
            {
                var spellData = _spellDatas[j];
                if (spellData.Spell == knowedSpell)
                {
                    spellData.IsKnown = true;

                    _knowedSpells.Add(spellData);
                }
            }
        }
    }

    private void DoMoveZ(GameObject gameObject)
    {
        var vector1 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 0.31f);

        gameObject.transform.DOMove(vector1, 1f).OnComplete(() => DoMoveZ2(gameObject)); 
            
    }

    private void DoMoveZ2(GameObject gameObject)
    {
        var vector2 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 0.6f);

        gameObject.transform.DOMove(vector2, 1f).OnComplete(() => DoMoveZ3(gameObject));
    }

    public void DoMoveZ3(GameObject gameObject)
    {
        var vector3 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 0.3f);

        gameObject.transform.DOMove(vector3, 1f).OnComplete(() => DoMoveZ(gameObject));
    }

    private void SpawnSpellPrefab()
    { 
        var spellData = _knowedSpells[_index];

        if (!spellData.IsKnown) return;

        Destroy(_createdObject);

        _createdObject = Instantiate(spellData.Prefab, _spawnpoint);
        _hintRunes.SetHintRunes(spellData.Spell);      
    }
}