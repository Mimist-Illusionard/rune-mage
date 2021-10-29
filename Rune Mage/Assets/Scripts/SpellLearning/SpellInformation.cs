using UnityEngine;
using UnityEngine.UI;


public class SpellInformation : MonoBehaviour
{
    private SpellInfo _spellInfo;

    [SerializeField] private Image _icon;
    [SerializeField] private Text _text;
    [SerializeField] private Image[] _runes;

    public void SetSpellInfo(SpellInfo spellInfo)
    {
        _spellInfo = spellInfo;

        _icon.sprite = _spellInfo.Spell.Sprite;
        _text.text = _spellInfo.Description;

        for (int i = 0; i < _runes.Length; i++)
        {
            var runeImage = _runes[i];

            if (_spellInfo.Spell.Runes.Count <= i)
            {
                runeImage.gameObject.SetActive(false);
            }
            else
            {
                runeImage.gameObject.SetActive(true);
                runeImage.sprite = _spellInfo.Spell.Runes[i].Sprite;
            }
        }
    }
}
