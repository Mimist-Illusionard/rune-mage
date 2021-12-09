using UnityEngine;

using TMPro;


public class LevelChoser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private SceneBehaviour _sceneBehaviour;

    [SerializeField] private float _maxLevelAmount;

    private int _levelCounter;

    public void Increase()
    {
        if (_levelCounter + 1 > _maxLevelAmount) return;

        _levelCounter++;
        _text.text = _levelCounter.ToString();

        _sceneBehaviour.ChangeSceneId(_levelCounter);
    }

    public void Decrease()
    {
        if (_levelCounter - 1 < 0) return;

        _levelCounter--;
        _text.text = _levelCounter.ToString();

        _sceneBehaviour.ChangeSceneId(_levelCounter);
    }
}
