using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void DealDamage(float value)
    {
        _currentHealth -= value;
    }

    public void Heal(float value)
    {
        _currentHealth += value;
    }
}
