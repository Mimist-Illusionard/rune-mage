using UnityEngine;


public class SpellBook : MonoBehaviour
{
    [SerializeField] private GameObject _book;
    [SerializeField] private SpellInformation _spellInformation;
    [SerializeField] private SpellSlot[] _spellSlots;

    private void Start()
    {
        for (int i = 0; i < _spellSlots.Length; i++)
        {
            var spellSlot = _spellSlots[i];
            spellSlot.SetSpellBook(this);
        }
    }

    public void Open()
    {
        PlayerManager.Singleton.GetCamera().SwitchCursorMode(false);

        var spells = SpellsSystem.Singleton.GetSpells();

        for (int i = 0; i < _spellSlots.Length; i++)
        {
            if (spells.Count <= i)
            {
                _spellSlots[i].gameObject.SetActive(false);
            }
            else
            {
                var spell = spells[i];

                _spellSlots[i].gameObject.SetActive(true);
                _spellSlots[i].SetSpell(spell);
            }
        }

        _book.SetActive(true);
    }

    public void Close()
    {
        PlayerManager.Singleton.GetCamera().SwitchCursorMode(true);

        _book.SetActive(false);
    }

    public void SetSpellInfo(SpellInfo spell)
    {
        _spellInformation.SetSpellInfo(spell);
    }
}
