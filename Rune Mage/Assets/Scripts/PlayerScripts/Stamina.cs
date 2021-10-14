using System;

using UnityEngine;


public class Stamina : MonoBehaviour, IExecute
{
	[SerializeField] private float _maxStamina = 100f;
	[SerializeField] private float _currentStamina;
	[SerializeField] private float _regen;

	public Action<float, float> OnStaminaChange;
	private bool _canRun;

    private void Start()
    {
		_currentStamina = _maxStamina;

		GameManager.Singleton.AddExecuteObject(this);
	}

	public void Execute()
	{
		StaminaCheckValue();
	}

	private void StaminaCheckValue()
	{
		if (_currentStamina >= _maxStamina)
		{
			_currentStamina = _maxStamina;
		}
		else if (_currentStamina <= 0)
		{
			_currentStamina = 1;
			_canRun = false;
		}
		if (_currentStamina >= 25f)
			_canRun = true;
	}

	public void Regen(float staminaChange)
	{
		_currentStamina += staminaChange * Time.deltaTime;

		OnStaminaChange?.Invoke(_currentStamina, _maxStamina);
	}

	public void SpentStamina(float staminaSpent)
    {
		_currentStamina -= staminaSpent * Time.deltaTime;

		OnStaminaChange?.Invoke(_currentStamina, _maxStamina);
	}

	public bool CanRun()
    {
		return _canRun;
	}

    private void OnDestroy()
    {
		GameManager.Singleton.RemoveExecuteObject(this);
    }
}
