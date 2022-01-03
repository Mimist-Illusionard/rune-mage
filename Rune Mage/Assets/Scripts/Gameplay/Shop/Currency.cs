using UnityEngine;


public class Currency : MonoBehaviour
{
    [SerializeField] private float _currency;

    public void AddCurrency(float value)
    {
        _currency += value;
    }

    public void RemoveCurrency(float value)
    {
        _currency -= value;
    }

    public float GetCurrency()
    {
        return _currency;
    }
}
