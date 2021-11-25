using System;
using System.Collections;

using UnityEngine;



public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float _maxHealth = 30f;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth { get; set; }

    public Action<float, float> OnHealthChange;
    public Action<float> OnValueGetted;

    public Action OnHealthZero;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        OnHealthChange?.Invoke(CurrentHealth, MaxHealth);
    }

    public void AddHealth(float value)
    {
        CurrentHealth += value;

        MinMaxClamp();

        OnHealthChange?.Invoke(CurrentHealth, MaxHealth);
        OnValueGetted?.Invoke(value);
    }

    public void RemoveHealth(float value)
    {
        CurrentHealth -= value;

        MinMaxClamp();

        OnHealthChange?.Invoke(CurrentHealth, MaxHealth);
        OnValueGetted?.Invoke(value);
    }

    private void MinMaxClamp()
    {
        if (CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            OnHealthZero?.Invoke();
        }
    }

    public void StartRegenHealing(float healingTick, float healthPerTick, float time)
    {
        StartCoroutine(RegenHealing(healingTick, healthPerTick, time));
    }

    private IEnumerator RegenHealing(float healingTick, float healthPerTick, float time)
    {
        var tickAmount = time / healingTick;

        for (int i = 0; i < tickAmount; i++)
        {
            AddHealth(healthPerTick);
            yield return new WaitForSeconds(healingTick);
        }

        yield return null;
    }
}
