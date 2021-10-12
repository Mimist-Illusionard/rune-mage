using System.Collections;
using UnityEngine;


public class Health : MonoBehaviour, IHealth
{
    public float MaxHealth => 30f;

    public float CurrentHealth { get; set; }

    private void Start()
    {
        CurrentHealth = 10f;
    }

    public void AddHealth(float value)
    {
        CurrentHealth += value;

        MinMaxClamp();
    }

    public void RemoveHealth(float value)
    {
        CurrentHealth -= value;

        MinMaxClamp();
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
