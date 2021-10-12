using System;

using UnityEngine;


public class Mana : MonoBehaviour, IExecute
{
    [SerializeField] private float _maxMane;
    [SerializeField] private float _currentMane;
    [SerializeField] private float _manaRegen;

    public Action<float, float> OnMahaChange;

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        ManaRegen();
    }

    private void ManaRegen()
    {
        Regen(_manaRegen);
        if (_currentMane >= _maxMane)
        {
            _currentMane = _maxMane;
        }
        if (_currentMane <= 0)
        {
            _currentMane = 0;
        }
    }

    public float GiveMana()
    {
        return _currentMane;
    }

    public void ManaChange(float change)
    {
        OnMahaChange?.Invoke(_currentMane, _maxMane);
        _currentMane += change;
    }

    public void Regen(float manaChange)
    {
        OnMahaChange?.Invoke(_currentMane, _maxMane);
        _currentMane += manaChange * Time.deltaTime;
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}