using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour, IExecute
{
	[SerializeField] private float _playerMaxStamina = 100f;
	[SerializeField] private float _playerStamina;
    [SerializeField] private float _playerMaxMane = 100f;
    [SerializeField] private float _playerMane;
    [SerializeField] private float _playerManaRegen;

    public Action<float, float> ManaUiSet;

	private Player _player;

	public static PlayerManager Singleton { get; private set; }

	private void Awake()
	{
		Singleton = this;
	}

    private void Start()
	{
        GameManager.Singleton.SetNewExecuteObject(this);
        _playerMane = _playerMaxMane;
		_playerStamina = _playerMaxStamina;
	}

	public void Execute()
	{
		StaminaRegenLogic();
        ManaManager();
	}

	private void StaminaRegenLogic()
	{
		if (_playerStamina >= _playerMaxStamina)
		{
			_playerStamina = _playerMaxStamina;
		}
		else if (_playerStamina <= 0)
		{
			_playerStamina = 1;
			_player._canRun = false;
		}
		if (_playerStamina >= 25f)
			_player._canRun = true;
	}

    private void ManaManager()
    {
        ManaRegen(_playerManaRegen);
        if (_playerMane >= _playerMaxMane)
        {
            _playerMane = _playerMaxMane;
        }
        if (_playerMane <= 0)
        {
            _playerMane = 0;
        }
    }

	public void StaminaManager(float staminaChange)
	{
		_playerStamina += staminaChange * Time.deltaTime;
	}

    public float GiveMana()
    {
        return _playerMane;
    }

    public void ManaChange(float change)
    {
        ManaUiSet?.Invoke(_playerMane, _playerMaxMane);
        _playerMane += change;
    }

    public void ManaRegen(float manaChange)
    {
        ManaUiSet?.Invoke(_playerMane, _playerMaxMane);
        _playerMane += manaChange * Time.deltaTime;
    }

	public void SetPlayer(Player player)
    {
		_player = player;
    }

	public Player GetPlayer()
	{
		return _player;
	}
}