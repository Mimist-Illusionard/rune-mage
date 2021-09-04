using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class RunesUi : MonoBehaviour
{
    [SerializeField] private Transform _currentSpellTransform;
    [SerializeField] private GameObject _runeIconPrefab;

    private List<GameObject> _runeIcons = new List<GameObject>();

    public static RunesUi Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }

    public void CreateRuneIcon(Rune rune)
    {
        var icon = Instantiate(_runeIconPrefab, _currentSpellTransform);
        icon.GetComponent<Image>().sprite = rune.Sprite;
        _runeIcons.Add(icon);
    }

    public void DeleteRuneIcons()
    {
        foreach (var rune in _runeIcons)
        {
            Destroy(rune);
        }
    }
}
