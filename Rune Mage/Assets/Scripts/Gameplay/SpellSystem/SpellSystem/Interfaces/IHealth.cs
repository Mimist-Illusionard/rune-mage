

public interface IHealth
{
    float MaxHealth { get; }
    float CurrentHealth { get; set; }

    void AddHealth(float value);
    void RemoveHealth(float value);
}
