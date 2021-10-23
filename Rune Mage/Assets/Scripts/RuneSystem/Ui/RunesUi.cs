using System.Collections.Generic;

using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;


public class RunesUi : MonoBehaviour
{
    [SerializeField] private Transform _currentSpellTransform;
    [SerializeField] private Transform _usedSpellTransform;

    [SerializeField] private GameObject _runeIconPrefab;
    [SerializeField] private GameObject _usedRuneIconPrefab;

    private List<GameObject> _runeIcons = new List<GameObject>();

    public static RunesUi Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }

    public void CreateRuneIcon(Rune rune)
    {
        CreateUsedRuneIcon(rune);

        var icon = Instantiate(_runeIconPrefab, _currentSpellTransform);
        icon.GetComponent<Image>().sprite = rune.Sprite;

        _runeIcons.Add(icon);
    }

    private void CreateUsedRuneIcon(Rune rune)
    {
        var icon = Instantiate(_usedRuneIconPrefab, _usedSpellTransform);
        icon.GetComponent<Image>().sprite = rune.Sprite;

        icon.transform.DOScale(1.3f, 0.5f).OnComplete(() => icon.transform.DOScale(1f, 0.4f));

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
