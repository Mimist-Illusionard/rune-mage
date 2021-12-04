using UnityEngine;
using UnityEngine.UI;


public class HintRunes : MonoBehaviour
{
    [SerializeField] private Image[] _images;

    public void SetHintRunes(Spell spell)
    {
        for (int i = 0; i < _images.Length; i++)
        {
            var runeImage = _images[i];

            if (spell.Runes.Count <= i)
            {
                runeImage.gameObject.SetActive(false);
            }
            else
            {
                runeImage.gameObject.SetActive(true);
                runeImage.sprite = spell.Runes[i].Sprite;
            }
        }
    }
}
