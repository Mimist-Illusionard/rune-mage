using UnityEngine;


public class Health : MonoBehaviour, IHealth
{
    public float MaxHealth => 30f;

    public float CurrentHealth { get; set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void AddHealth(float value)
    {
        CurrentHealth += value;
    }

    public void RemoveHealth(float value)
    {
        CurrentHealth -= value;
    }
}
