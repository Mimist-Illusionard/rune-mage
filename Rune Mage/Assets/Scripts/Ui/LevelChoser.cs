using UnityEngine;
using TMPro;

public class LevelChoser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _levelCounter;

    public void AddOne()
    {
        _levelCounter++;
        _text.text = _levelCounter.ToString();
    }

    public void MinusOne()
    {
        if (_levelCounter - 1 < 0) return;

        _levelCounter--;
        _text.text = _levelCounter.ToString();
    }
}
