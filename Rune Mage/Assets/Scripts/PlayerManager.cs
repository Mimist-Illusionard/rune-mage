using UnityEngine;


public class PlayerManager : MonoBehaviour, IExecute
{
	[SerializeField] private float _playerMaxStamina = 100f;
	[SerializeField] private float _playerStamina;

	private Player _player;

	public static PlayerManager Singleton { get; private set; }

	private void Awake()
	{
		Singleton = this;
	}

    private void Start()
	{
		_playerStamina = _playerMaxStamina;
	}

	public void Execute()
	{
		StaminaRegenLogic();
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

	public void StaminaManager(float staminaChange)
	{
		_playerStamina += staminaChange * Time.deltaTime;
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